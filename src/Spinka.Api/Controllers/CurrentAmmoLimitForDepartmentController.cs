using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.CurrentAmmoLimitForDepartments.Commands;
using Spinka.Application.CurrentAmmoLimitForDepartments.Queries;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.Dispatchers;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentAmmoLimitForDepartmentController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public CurrentAmmoLimitForDepartmentController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet("UnitDepartment/{id}")]
        public async Task<ActionResult<IEnumerable<LimitForDepartmentViewModel>>> GetLimitsForDepartment(int id)
        {
            var limitsForDepartment = await _dispatcher.QueryAsync<GetAmmoLimitsForDepartment, IEnumerable<LimitForDepartmentViewModel>>(new GetAmmoLimitsForDepartment
                {
                    UnitDepartmentId = id
                });
            
            return new JsonResult(limitsForDepartment);
        }
        
        [HttpGet("Ammo/{id}")]
        public async Task<ActionResult<IEnumerable<LimitForAmmoViewModel>>> GetLimitsForAmmo(int id)
        {
            var limitsForAmmo = await _dispatcher.QueryAsync<GetAmmoLimitsForAmmo, IEnumerable<LimitForAmmoViewModel>>(new GetAmmoLimitsForAmmo
            {
                AmmoId = id
            });
            
            return new JsonResult(limitsForAmmo);
        }
        
        [HttpPost]
        public async Task<ActionResult> AssignedLimit([FromBody] AssignedLimitToUnit command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateLimit([FromBody] UpdateLimit command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}