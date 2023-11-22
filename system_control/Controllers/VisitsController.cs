using BLL.Models.Visit;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/visits")]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitsController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _visitService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var visits = await _visitService.GetAllWithFilterAsync(sieveModel);
            return Ok(visits);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVisitModel createVisitModel)
        {
            var visit = await _visitService.CreateAsync(createVisitModel);
            return Ok(visit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateVisitModel updateVisitModel)
        {
            await _visitService.UpdateAsync(id, updateVisitModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _visitService.DeleteAsync(id);
            return NoContent();
        }
    }
}
