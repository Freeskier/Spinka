using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.AssignedAmmo.Commands;
using Spinka.Application.Dispatchers;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedAmmoController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AssignedAmmoController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpPost]
        public async Task<ActionResult> AssignedAmmoForEduBlock([FromBody] AssignedAmmoForEduBlock command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }
    }
}