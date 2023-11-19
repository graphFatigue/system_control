using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Client?> GetByIdAsync(int id);
        Task<Client?> GetByNameAsync(string firstName, string lastName);
    }
}
