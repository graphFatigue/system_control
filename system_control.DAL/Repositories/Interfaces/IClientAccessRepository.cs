using Core.Entity;

namespace DAL.Repositories.Interfaces
{
    public interface IClientAccessRepository : IGenericRepository<ClientAccess>
    {
        Task<ClientAccess?> GetByRelationIdAsync(int relationId);
    }
}
