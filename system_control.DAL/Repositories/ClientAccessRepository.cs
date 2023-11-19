using Core.Entity;
using DAL;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories
{
    public class ClientAccessRepository : GenericRepository<ClientAccess>, IClientAccessRepository
    {
        public ClientAccessRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<ClientAccess?> GetByRelationIdAsync(int relationId)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.RelationId == relationId);
        }
    }
}
