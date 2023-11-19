using Core.Entity;
using DAL;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories
{
    public class VisitRepository : GenericRepository<Visit>, IVisitRepository
    {
        public VisitRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<Visit?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
