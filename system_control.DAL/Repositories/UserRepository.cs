using Core.Entity;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User?> GetByNameAsync(string firstName, string lastName)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
