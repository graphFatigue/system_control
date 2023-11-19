using Core.Entity;
using DAL;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<Organization?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Organization?> GetByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
