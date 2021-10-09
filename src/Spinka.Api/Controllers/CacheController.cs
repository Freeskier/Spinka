using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Caches.Commands;
using Spinka.Application.Dispatchers;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public CacheController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpPost]
        public async Task<ActionResult> RestartCache([FromBody] RestartCache command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }
    }
}