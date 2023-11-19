using Core.Entity;
using DAL;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<Staff?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        async Task<Staff?> IStaffRepository.GetByNameAndDepartmentAsync(string firstName, string lastName, int departmentId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.User.FirstName == firstName && x.User.LastName == lastName && x.DepartmentId == departmentId);
        }
    }
}
