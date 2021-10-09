using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.TrainingLogs.Queries;
using Spinka.Application.TrainingLogs.ViewModels;

namespace Spinka.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingLogController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public TrainingLogController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost("ByGroupId")]
        public async Task<ActionResult<IEnumerable<TrainingLogByGroupIdViewModel>>> 
            GetTrainingLogsByGroupId([FromBody] GetTrainingLogsByGroupId query)
        {
            var trainingLogs = await _dispatcher.QueryAsync<GetTrainingLogsByGroupId,
                    IEnumerable<TrainingLogByGroupIdViewModel>>(query);
            return new JsonResult(trainingLogs);
        }
        
        [HttpPost("ByGroupWithEdu")]
        public async Task<ActionResult<IEnumerable<TrainingLogByGroupWithEduViewModel>>> 
            GetTrainingLogsByGroupId([FromBody] GetTrainingLogByGroupWithEdu query)
        {
            var trainingLogs = await _dispatcher.QueryAsync<GetTrainingLogByGroupWithEdu,
                    IEnumerable<TrainingLogByGroupWithEduViewModel>>(query);
            return new JsonResult(trainingLogs);
        }

        [HttpGet("ByEduBlock/{id}")]
        public async Task<ActionResult<IEnumerable<TrainingLogByEduBlockViewModel>>>
            GetTrainingLogByEduBlock(int id)
        {
            var trainingLogs = await _dispatcher.QueryAsync<GetTrainingLogByEduBlock,
                IEnumerable<TrainingLogByEduBlockViewModel>>(new GetTrainingLogByEduBlock(id));
            return new JsonResult(trainingLogs);
        }
    }
}