using BLL.Models.User;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<PagedList<UserModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> CreateAsync(CreateUserModel createUserModel);
        Task UpdateAsync(int id, UpdateUserModel updateUserModel);
        Task DeleteAsync(int id);
    }
}
