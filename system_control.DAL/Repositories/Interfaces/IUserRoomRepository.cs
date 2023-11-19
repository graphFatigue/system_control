using Core.Entity;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRoomRepository : IGenericRepository<UserRoom>
    {
        Task<UserRoom?> GetByRelationIdAsync(int relationId);
        Task<UserRoom?> GetByUserRoomAsync(int userId, int roomId);
    }
}
