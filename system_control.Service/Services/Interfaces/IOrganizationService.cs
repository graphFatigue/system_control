using BLL.Models.Organization;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationModel>> GetAllAsync();
        Task<PagedList<OrganizationModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<OrganizationModel> GetByIdAsync(int id);
        Task<OrganizationModel> CreateAsync(CreateOrganizationModel createOrganizationModel);
        Task UpdateAsync(int id, UpdateOrganizationModel updateOrganizationModel);
        Task DeleteAsync(int id);
    }
}
