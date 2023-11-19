using Core.Entity;
using DAL;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace DAL.Repositories
{
    public class UserRoomRepository : GenericRepository<UserRoom>, IUserRoomRepository
    {
        public UserRoomRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<UserRoom?> GetByRelationIdAsync(int relationId)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.RelationId == relationId);
        }

        public async Task<UserRoom?> GetByUserRoomAsync(int userId, int roomId)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.UserId == userId && e.RoomId == roomId);
        }
    }
}
