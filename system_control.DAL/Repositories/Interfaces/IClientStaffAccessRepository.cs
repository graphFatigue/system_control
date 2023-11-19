using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IClientStaffAccessRepository : IGenericRepository<ClientStaffAccess>
    {
        Task<ClientStaffAccess?> GetByRelationIdAsync(int relationId);

        Task<ClientStaffAccess?> GetByClientStaffDepartmmentAsync(int clientId, int staffId, int departmentId);
    }
}
