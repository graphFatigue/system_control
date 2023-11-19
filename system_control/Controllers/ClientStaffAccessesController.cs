using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/clientStaffAccesses")]
    public class ClientStaffAccessesController: ControllerBase
    {
        private readonly IClientStaffAccessService _clientStaffAccessService;

        public ClientStaffAccessesController(IClientStaffAccessService clientStaffAccessService)
        {
            _clientStaffAccessService = clientStaffAccessService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var clientStaffAccesses = await _clientStaffAccessService.GetAllAsync();
            return Ok(clientStaffAccesses);
        }
    }
}
