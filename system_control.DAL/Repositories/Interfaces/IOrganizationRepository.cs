using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IOrganizationRepository : IGenericRepository<Organization>
    {
        Task<Organization?> GetByIdAsync(int id);
        Task<Organization?> GetByNameAsync(string name);
    }
}
