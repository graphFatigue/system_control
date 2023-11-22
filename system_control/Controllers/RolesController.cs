using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Entity;
using Microsoft.AspNetCore.Http.HttpResults;

namespace system_control.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("all")]
        public IActionResult GetAll() => Ok(_roleManager.Roles.ToList());

        //[HttpGet]
        //public IActionResult GetRoleByName(string name) => Ok(_roleManager.Roles.Where(r => r.Name == name).FirstOrDefault());

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    CreatedAtRoute(nameof(GetAll), result);//, new { name = result.Name }, organization);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Ok(name);
        }
    }
}