using BLL.Models.Admin;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminModel>> GetAllAsync();
        Task<PagedList<AdminModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<AdminModel> GetByIdAsync(int id);
        Task<AdminModel> CreateAsync(CreateAdminModel createAdminModel);
        Task UpdateAsync(int id, UpdateAdminModel updateAdminModel);
        Task DeleteAsync(int id);
    }
}
