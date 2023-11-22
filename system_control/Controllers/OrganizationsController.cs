using BLL.Models.Organization;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/organizations")]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var organizations = await _organizationService.GetAllAsync();
            return Ok(organizations);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var organizations = await _organizationService.GetAllWithFilterAsync(sieveModel);
            return Ok(organizations);
        }

        [HttpGet("{id}", Name = nameof(GetOrganizationById))]
        public async Task<IActionResult> GetOrganizationById(int id)
        {
            var organization = await _organizationService.GetByIdAsync(id);
            return Ok(organization);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrganizationModel createOrganizationModel)
        {
                var organization = await _organizationService.CreateAsync(createOrganizationModel);
                return CreatedAtRoute(nameof(GetOrganizationById), new { id = organization.Id }, organization);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateOrganizationModel updateOrganizationModel)
        {
            await _organizationService.UpdateAsync(id, updateOrganizationModel);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _organizationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
