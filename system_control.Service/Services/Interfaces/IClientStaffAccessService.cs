using BLL.Models.ClientStaffAccess;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IClientStaffAccessService
    {
        Task<IEnumerable<ClientStaffAccessModel>> GetAllAsync();
        Task<PagedList<ClientStaffAccessModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<ClientStaffAccessModel> GetByRelationIdAsync(int RelationId);
        Task<ClientStaffAccessModel> CreateAsync(CreateClientStaffAccessModel createClientStaffAccessModel);
        Task UpdateAsync(int RelationId, UpdateClientStaffAccessModel updateClientStaffAccessModel);
        Task DeleteAsync(int RelationId);
    }
}
