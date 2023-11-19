using Core.Entity;
using DAL;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Client?> GetByNameAsync(string firstName, string lastName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.User.FirstName == firstName && x.User.LastName == lastName);
        }
    }
}
