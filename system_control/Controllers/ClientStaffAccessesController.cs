using BLL.Models.ClientAccess;
using BLL.Models.ClientStaffAccess;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/client-staff-accesses")]
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

        [HttpPost]
        public async Task<IActionResult> Post(CreateClientStaffAccessModel createClientStaffAccessModel)
        {
            var clientStaffAccess = await _clientStaffAccessService.CreateAsync(createClientStaffAccessModel);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClientStaffAccessModel updateClientStaffAccessModel)
        {
            await _clientStaffAccessService.UpdateAsync(id, updateClientStaffAccessModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientStaffAccessService.DeleteAsync(id);
            return NoContent();
        }
    }
}
