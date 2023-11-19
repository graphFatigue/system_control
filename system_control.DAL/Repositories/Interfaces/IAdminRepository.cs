using Core.Entity;

namespace DAL.Repositories.Interfaces
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin?> GetByIdAsync(int id);
    }
}
