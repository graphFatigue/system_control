using Core.Entity;
using DAL;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories
{
    public class ClientStaffAccessRepository : GenericRepository<ClientStaffAccess>, IClientStaffAccessRepository
    {
        public ClientStaffAccessRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<ClientStaffAccess?> GetByClientStaffDepartmmentAsync(int clientId, int staffId, int departmentId)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.ClientId == clientId && e.StaffId == staffId && e.DepartmentId == departmentId);
        }

        public async Task<ClientStaffAccess?> GetByRelationIdAsync(int relationId)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.RelationId == relationId);
        }
    }
}
