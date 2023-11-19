using Core.Entity;

namespace DAL.Repositories.Interfaces
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        Task<Staff?> GetByIdAsync(int id);
        Task<Staff?> GetByNameAndDepartmentAsync(string firstName, string lastName, int departmentId);
    }
}
