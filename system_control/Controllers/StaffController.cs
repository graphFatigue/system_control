using BLL.Models.Staff;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var staff = await _staffService.GetAllAsync();
            return Ok(staff);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var staff = await _staffService.GetAllWithFilterAsync(sieveModel);
            return Ok(staff);
        }

        [HttpGet("{id}", Name = nameof(GetStaffById))]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await _staffService.GetByIdAsync(id);
            return Ok(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateStaffModel createStaffModel)
        {
            var staff = await _staffService.CreateAsync(createStaffModel);
            return CreatedAtRoute(nameof(GetStaffById), new { id = staff.Id }, staff);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateStaffModel updateStaffModel)
        {
            await _staffService.UpdateAsync(id, updateStaffModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffService.DeleteAsync(id);
            return NoContent();
        }
    }
}
