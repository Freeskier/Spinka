using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.EventTypes.Commands;
using Spinka.Application.EventTypes.Queriers;
using Spinka.Application.EventTypes.ViewModels;
using Spinka.Application.MajorEvents.Queries;
using Spinka.Application.MajorEvents.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public EventTypeController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTypeViewModel>>> GetAll()
        {
            var eventTypes =
                await _dispatcher.QueryAsync<GetEventTypes, IEnumerable<EventTypeViewModel>>(new GetEventTypes());
            return new JsonResult(eventTypes);
        } 
        
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTypeViewModel>> Get(int id)
        {
            var eventType =
                await _dispatcher.QueryAsync<GetEventType, EventTypeViewModel>(new GetEventType(id));
            return new JsonResult(eventType);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEventType(CreateEventType command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(null, null, null);
        }
    }
}