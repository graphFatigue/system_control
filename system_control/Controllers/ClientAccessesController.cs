using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/clientAccesses")]
    public class ClientAccessesController: ControllerBase
    {
        private readonly IClientAccessService _clientAccessService;

        public ClientAccessesController(IClientAccessService clientAccessService)
        {
            _clientAccessService = clientAccessService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var clientAccesses = await _clientAccessService.GetAllAsync();
            return Ok(clientAccesses);
        }
    }
}
