using Core.Shared;
using Sieve.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PagedList<TEntity>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
