using BLL.Models.Client;
using BLL.Models.ClientAccess;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/client-accesses")]
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

        [HttpPost]
        public async Task<IActionResult> Post(CreateClientAccessModel createClientAccessModel)
        {
            var clientAccess = await _clientAccessService.CreateAsync(createClientAccessModel);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClientAccessModel updateClientAccessModel)
        {
            await _clientAccessService.UpdateAsync(id, updateClientAccessModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientAccessService.DeleteAsync(id);
            return NoContent();
        }
    }
}
