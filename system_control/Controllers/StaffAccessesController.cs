using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/staffAccesses")]
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
    }
}
