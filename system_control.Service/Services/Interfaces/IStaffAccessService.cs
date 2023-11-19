using BLL.Models.StaffAccess;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IStaffAccessService
    {
        Task<IEnumerable<StaffAccessModel>> GetAllAsync();
        Task<PagedList<StaffAccessModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<StaffAccessModel> GetByRelationIdAsync(int RelationId);
        Task<StaffAccessModel> CreateAsync(CreateStaffAccessModel createStaffAccessModel);
        Task UpdateAsync(int RelationId, UpdateStaffAccessModel updateStaffAccessModel);
        Task DeleteAsync(int RelationId);
    }
}
