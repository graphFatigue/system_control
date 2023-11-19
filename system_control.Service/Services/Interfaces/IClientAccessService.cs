using BLL.Models.ClientAccess;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IClientAccessService
    {
        Task<IEnumerable<ClientAccessModel>> GetAllAsync();
        Task<PagedList<ClientAccessModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<ClientAccessModel> GetByRelationIdAsync(int RelationId);
        Task<ClientAccessModel> CreateAsync(CreateClientAccessModel createClientAccessModel);
        Task UpdateAsync(int RelationId, UpdateClientAccessModel updateClientAccessModel);
        Task DeleteAsync(int RelationId);
    }
}
