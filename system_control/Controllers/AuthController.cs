using BLL.Models.Auth;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginModel loginModel,
            CancellationToken cancellationToken)
        {
            var tokenModel = await _authService.LoginAsync(loginModel, cancellationToken);
            return Ok(tokenModel);
        }

        [HttpPost("login-external")]
        public async Task<IActionResult> LoginExternal(
            ExternalAuthModel externalAuthModel,
            CancellationToken cancellationToken)
        {
            var tokenModel = await _authService.LoginExternalAsync(externalAuthModel, cancellationToken);
            return Ok(tokenModel);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(
            SignupModel signupModel,
            CancellationToken cancellationToken)
        {
            var userModel = await _authService.SignupAsync(signupModel, cancellationToken);
            return Ok(userModel);
        }
    }
}
