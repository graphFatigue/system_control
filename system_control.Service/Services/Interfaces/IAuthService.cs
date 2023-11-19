using BLL.Models.Auth;
using BLL.Models.User;

namespace BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<JwtTokenModel> LoginAsync(LoginModel model, CancellationToken cancellationToken = default);
        Task<JwtTokenModel?> LoginExternalAsync(ExternalAuthModel model, CancellationToken cancellationToken = default);
        Task<UserModel> SignupAsync(SignupModel model, CancellationToken cancellationToken = default);
    }
}
