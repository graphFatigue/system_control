using BLL.Models.Room;
using Core.Shared;
using Sieve.Models;

namespace BLL.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomModel>> GetAllAsync();
        Task<PagedList<RoomModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<RoomModel> GetByIdAsync(int id);
        Task<RoomModel> CreateAsync(CreateRoomModel createRoomModel);
        Task UpdateAsync(int id, UpdateRoomModel updateRoomModel);
        Task DeleteAsync(int id);
    }
}
