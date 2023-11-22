using BLL.Models.Room;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var rooms = await _roomService.GetAllWithFilterAsync(sieveModel);
            return Ok(rooms);
        }

        [HttpGet("{id}", Name = nameof(GetRoomById))]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            return Ok(room);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomModel createRoomModel)
        {
            var room = await _roomService.CreateAsync(createRoomModel);
            return CreatedAtRoute(nameof(GetRoomById), new { id = room.Id }, room);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRoomModel updateRoomModel)
        {
            await _roomService.UpdateAsync(id, updateRoomModel);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.DeleteAsync(id);
            return NoContent();
        }
    }
}
