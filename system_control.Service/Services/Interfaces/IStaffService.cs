using BLL.Models.Staff;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffModel>> GetAllAsync();
        Task<PagedList<StaffModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<StaffModel> GetByIdAsync(int id);
        Task<StaffModel> CreateAsync(CreateStaffModel createStaffModel);
        Task UpdateAsync(int id, UpdateStaffModel updateStaffModel);
        Task DeleteAsync(int id);
    }
}
