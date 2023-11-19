using BLL.Models.UserRoom;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IUserRoomService
    {
        Task<IEnumerable<UserRoomModel>> GetAllAsync();
        Task<PagedList<UserRoomModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<UserRoomModel> GetByRelationIdAsync(int relationId);
        Task<UserRoomModel> CreateAsync(CreateUserRoomModel createUserRoomModel);
        Task UpdateAsync(int relationId, UpdateUserRoomModel updateUserRoomModel);
        Task DeleteAsync(int relationId);
    }
}
