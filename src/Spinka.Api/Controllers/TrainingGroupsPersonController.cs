using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.TrainingGroupsPerson.Commands;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingGroupsPersonController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public TrainingGroupsPersonController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpPost]
        public async Task<ActionResult> AddPersonToGroup([FromBody] AddPersonToGroup command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }
        
        [HttpPut]
        public async Task<ActionResult> DeletePersonFromGroup([FromBody] DeletePersonFromGroup command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }
    }
}