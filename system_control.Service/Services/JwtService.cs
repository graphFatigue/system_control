using BLL.Models.Auth;
using BLL.Models.Settings;
using BLL.Services.Interfaces;
using Core.Entity;
using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly GoogleSettings _googleSettings;

        public JwtService(
            IOptions<JwtSettings> jwtSettings,
            IOptions<GoogleSettings> googleSettings)
        {
            _jwtSettings = jwtSettings.Value;
            _googleSettings = googleSettings.Value;
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<List<Claim>> GetClaimsAsync(User user)
        {
            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

            // Add roles of the user to the claims 

            return claims;
        }

        public Task<List<Claim>> GetClaimsAsync(string name)
        {
            return Task.FromResult(new List<Claim>
        {
            new(JwtRegisteredClaimNames.Name, name),
           // Add a "Guest" role if necessarry
        });
        }

        public JwtSecurityToken GenerateToken(SigningCredentials signingCredentials,
            IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials);

            return token;
        }

        public async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(ExternalAuthModel externalAuth)
        {
            try
            {
                if (_googleSettings.ClientId != null)
                {
                    var settings = new GoogleJsonWebSignature.ValidationSettings
                    {
                        Audience = new List<string> { _googleSettings.ClientId }
                    };

                    return await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }
    }
}
