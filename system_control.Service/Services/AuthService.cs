using AutoMapper;
using BLL.Models.Auth;
using BLL.Models.User;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Exceptions.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AuthService(
            IJwtService jwtService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        public async Task<JwtTokenModel> LoginAsync(
            LoginModel model,
            CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new InvalidLoginException();
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded)
            {
                throw new InvalidLoginException();
            }

            var claims = await _jwtService.GetClaimsAsync(user);
            var signingCredentials = _jwtService.GetSigningCredentials();
            var token = _jwtService.GenerateToken(signingCredentials, claims);

            return new JwtTokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }

        public async Task<JwtTokenModel?> LoginExternalAsync(
            ExternalAuthModel model,
            CancellationToken cancellationToken = default)
        {
            var payload = await _jwtService.VerifyGoogleToken(model);

            if (payload == null)
            {
                return null;
            }

            var info = new UserLoginInfo(model.Provider, payload.Subject, model.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user == null)
                {
                    user = new User { Email = payload.Email, UserName = payload.Email };
                    await _userManager.CreateAsync(user);

                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            var claims = await _jwtService.GetClaimsAsync(user);
            var signingCredentials = _jwtService.GetSigningCredentials();
            var token = _jwtService.GenerateToken(signingCredentials, claims);

            return new JwtTokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }

        public async Task<UserModel> SignupAsync(
            SignupModel model,
            CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new FailedSignupException(result.ToString());
            }

            // Send email confirmation
            // Add to default role if needed

            return _mapper.Map<UserModel>(user);
        }
    }
}
