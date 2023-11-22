using BLL.Models.ClientStaffAccess;
using BLL.Models.StaffAccess;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/staff-accesses")]
    public class StaffAccessesController : ControllerBase
    {
        private readonly IStaffAccessService _staffAccessService;

        public StaffAccessesController(IStaffAccessService staffAccessService)
        {
            _staffAccessService = staffAccessService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var staffAccesses = await _staffAccessService.GetAllAsync();
            return Ok(staffAccesses);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateStaffAccessModel createStaffAccessModel)
        {
            var staffAccess = await _staffAccessService.CreateAsync(createStaffAccessModel);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateStaffAccessModel updateStaffAccessModel)
        {
            await _staffAccessService.UpdateAsync(id, updateStaffAccessModel);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffAccessService.DeleteAsync(id);
            return NoContent();
        }
    }
}
