using BLL.Models.StaffAccess;
using BLL.Models.UserRoom;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/user-rooms")]
    public class UserRoomsController : ControllerBase
    {
        private readonly IUserRoomService _userRoomService;

        public UserRoomsController(IUserRoomService userRoomService)
        {
            _userRoomService = userRoomService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var userRooms = await _userRoomService.GetAllAsync();
            return Ok(userRooms);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRoomModel createUserRoomModel)
        {
            var userRoom = await _userRoomService.CreateAsync(createUserRoomModel);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserRoomModel updateUserRoomModel)
        {
            await _userRoomService.UpdateAsync(id, updateUserRoomModel);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRoomService.DeleteAsync(id);
            return NoContent();
        }
    }
}
