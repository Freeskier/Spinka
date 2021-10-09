using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.EduBlocks.Commands;
using Spinka.Application.EduBlocks.Queries;
using Spinka.Application.EduBlocks.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EduBlockController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public EduBlockController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EduBlockViewModel>>> GetAll()
        {
            var eduBlocks = await _dispatcher.QueryAsync<GetEduBlocks, IEnumerable<EduBlockViewModel>>(new GetEduBlocks());
            
            return new JsonResult(eduBlocks);
        }
        
        [HttpGet("MedicalService")]
        public async Task<ActionResult<IEnumerable<EduBlockViewModelForMedical>>> GetAllWithMedicalService()
        {
            var eduBlocks = await _dispatcher.QueryAsync<GetEduBlocksWithMedicalService, IEnumerable<EduBlockViewModelForMedical>>(new GetEduBlocksWithMedicalService());
            
            return new JsonResult(eduBlocks);
        } 
        
        [HttpGet("IconsInfo/{id}")]
        public async Task<ActionResult<IconsInfoViewModel>> GetAllWithMedicalService(int id)
        {
            var info = await _dispatcher.QueryAsync<GetEduBlockIconsInfo, IconsInfoViewModel>(new GetEduBlockIconsInfo(id));
            
            return new JsonResult(info);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<EduBlockDetailViewModel>> GetDetail(int id)
        {
            var eduBlock = await _dispatcher.QueryAsync<GetEduBlock, EduBlockDetailViewModel>(new GetEduBlock { Id = id });
            
            return new JsonResult(eduBlock);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEduBlock([FromBody] CreateEduBlock command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(nameof(CreateEduBlock), command.EduBlockId);
        }
        
        [HttpPost("Edit")]
        public async Task<ActionResult> EditEduBlock([FromBody] EditEduBlock command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(nameof(EditEduBlock), command.EduBlockId);
        }
        
        [HttpPut("Approve")]
        public async Task<ActionResult> ApproveEduBlock([FromBody] ApproveEduBlock command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
        
        [HttpPut("Cancel")]
        public async Task<ActionResult> CancelEduBlock([FromBody] CancelEduBlock command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
        
        [HttpGet("Month/{monthNumber}")]
        public async Task<ActionResult<IEnumerable<EduBlockToApproveViewModel>>> GetEduBlocksInMonth(int monthNumber)
        {
            var eduBlocks = await _dispatcher.QueryAsync<GetEduBlocksInMonth, IEnumerable<EduBlockToApproveViewModel>>(new GetEduBlocksInMonth { MonthNumber = monthNumber });
            
            return new JsonResult(eduBlocks);
        }
        
        [HttpGet("{id}/MajorEvent")]
        public async Task<ActionResult<MajorEventAssignedToEduBlockViewModel>> GetMajorEventAssignedToEduBlock(int id)
        {
            var eduBlocks = await _dispatcher.QueryAsync<GetMajorEventAssignedToEduBlock, MajorEventAssignedToEduBlockViewModel>
                (new GetMajorEventAssignedToEduBlock { EduBlockId = id });
            return new JsonResult(eduBlocks);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEduBlock([FromBody] DeleteEduBlock command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
        }
        
    }
}