using Core.Entity;

namespace DAL.Repositories.Interfaces
{
    public interface IVisitRepository : IGenericRepository<Visit>
    {
        Task<Visit?> GetByIdAsync(int id);
    }
}
