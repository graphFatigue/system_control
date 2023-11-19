using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<Room?> GetByIdAsync(int id);
        Task<Room?> GetByNumberAsync(int number, string departmentAddress);
    }
}
