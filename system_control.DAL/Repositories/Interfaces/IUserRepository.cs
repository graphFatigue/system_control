using Core.Entity;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByNameAsync(string firstName, string lastName);
    }
}
