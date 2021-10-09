using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.EduBlocks.Queries;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Application.MajorEvents.Commands;
using Spinka.Application.MajorEvents.Queries;
using Spinka.Application.MajorEvents.Queries.Handlers;
using Spinka.Application.MajorEvents.ViewModels;
using Spinka.Application.TrainingGroupsPerson.Commands;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorEventController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public MajorEventController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MajorEventViewModel>>> GetAll()
        {
            var majorEvents =
                await _dispatcher.QueryAsync<GetMajorEvents, IEnumerable<MajorEventViewModel>>(new GetMajorEvents());
            return new JsonResult(majorEvents);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MajorEventViewModel>> Get(int id)
        {
            var majorEvent =
                await _dispatcher.QueryAsync<GetMajorEvent, MajorEventViewModel>(new GetMajorEvent(id));
            return new JsonResult(majorEvent);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMajorEvent([FromBody] CreateMajorEvent command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(null, null, null);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMajorEvent([FromBody] DeleteMajorEvent command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(null, null, null);
        }

        [HttpPut("AddEduBlockToMajorEvent")]
        public async Task<ActionResult> AddEduBlockToMajorEvent([FromBody] AddEduBlockToMajorEvent command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(null, null, null);
        }
        
        [HttpGet("{id}/EduBlocks")]
        public async Task<ActionResult<IEnumerable<EduBlockViewModel>>> GetEduBlocksAssignedToMajorEvent(int id)
        {
            var eduBlocks =
                await _dispatcher.QueryAsync<GetEduBlocksAssignedToMajorEvent, IEnumerable<EduBlockViewModel>>(new GetEduBlocksAssignedToMajorEvent { MajorEventId = id});
            return new JsonResult(eduBlocks);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> EditMajorEvent([FromBody] EditMajorEvent command)
        {
            await _dispatcher.SendAsync(command);
            return new NoContentResult();
        }

        [HttpPost("Date")] 
        public async Task<ActionResult<IEnumerable<MajorEventViewModel>>> GetMajorEventBasedOnTIme([FromBody] GetMajorEventInDate query)
        {
            var majorEvents =  await _dispatcher.QueryAsync<GetMajorEventInDate, IEnumerable<MajorEventViewModel>>(
                query);
            return new JsonResult(majorEvents);
        }
    }
}