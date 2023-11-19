using BLL.Models.Client;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientModel>> GetAllAsync();
        Task<PagedList<ClientModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<ClientModel> GetByIdAsync(int id);
        Task<ClientModel> CreateAsync(CreateClientModel createClientModel);
        Task UpdateAsync(int id, UpdateClientModel updateClientModel);
        Task DeleteAsync(int id);
    }
}
