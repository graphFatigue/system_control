using BLL.Models.Client;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var clients = await _clientService.GetAllWithFilterAsync(sieveModel);
            return Ok(clients);
        }

        [HttpGet("{id}", Name = nameof(GetClientById))]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateClientModel createClientModel)
        {
            var client = await _clientService.CreateAsync(createClientModel);
            return CreatedAtRoute(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClientModel updateClientModel)
        {
            await _clientService.UpdateAsync(id, updateClientModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
