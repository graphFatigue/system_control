using BLL.Models.Admin;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/admins")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var admins = await _adminService.GetAllAsync();
            return Ok(admins);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var admins = await _adminService.GetAllWithFilterAsync(sieveModel);
            return Ok(admins);
        }

        [HttpGet("{id}", Name = nameof(GetAdminById))]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminService.GetByIdAsync(id);
            return Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAdminModel createAdminModel)
        {
            var admin = await _adminService.CreateAsync(createAdminModel);
            return CreatedAtRoute(nameof(GetAdminById), new { id = admin.Id }, admin);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateAdminModel updateAdminModel)
        {
            await _adminService.UpdateAsync(id, updateAdminModel);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _adminService.DeleteAsync(id);
            return NoContent();
        }
    }
}
