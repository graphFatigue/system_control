using BLL.Models.Visit;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IVisitService
    {
        Task<IEnumerable<VisitModel>> GetAllAsync();
        Task<PagedList<VisitModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<VisitModel> GetByIdAsync(int id);
        Task<VisitModel> CreateAsync(CreateVisitModel createVisitModel);
        Task UpdateAsync(int id, UpdateVisitModel updateVisitModel);
        Task DeleteAsync(int id);
    }
}
