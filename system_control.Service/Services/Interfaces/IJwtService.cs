using BLL.Models.Auth;
using Core.Entity;
using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace BLL.Services.Interfaces
{
    public interface IJwtService
    {
        SigningCredentials GetSigningCredentials();
        Task<List<Claim>> GetClaimsAsync(User user);
        JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims);
        Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(ExternalAuthModel externalAuth);
    }
}
