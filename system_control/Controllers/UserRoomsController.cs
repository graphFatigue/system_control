using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/userRooms")]
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
    }
}
