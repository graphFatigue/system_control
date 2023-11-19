using BLL.Models.Department;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetAllAsync();
        Task<PagedList<DepartmentModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<DepartmentModel> GetByIdAsync(int id);
        Task<DepartmentModel> CreateAsync(CreateDepartmentModel createDepartmentModel);
        Task UpdateAsync(int id, UpdateDepartmentModel updateDepartmentModel);
        Task DeleteAsync(int id);
    }
}
