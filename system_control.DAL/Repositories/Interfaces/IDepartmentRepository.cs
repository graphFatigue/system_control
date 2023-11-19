using Core.Entity;

namespace DAL.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department?> GetByIdAsync(int id);
        Task<Department?> GetByAddressAsync(string address);
    }
}
