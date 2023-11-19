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
    public class StaffAccessRepository : GenericRepository<StaffAccess>, IStaffAccessRepository
    {
        public StaffAccessRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<StaffAccess?> GetByRelationIdAsync(int relationId)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.RelationId == relationId);
        }
    }
}
