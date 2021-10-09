using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.TrainingAreas.Queries;
using Spinka.Application.TrainingAreas.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingAreaController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public TrainingAreaController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingAreaViewModel>>> GetAll()
        {
            var trainingAreas = await _dispatcher.QueryAsync<GetTrainingAreas, IEnumerable<TrainingAreaViewModel>>(new GetTrainingAreas());
            
            return new JsonResult(trainingAreas);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingAreaDetailViewModel>> GetDetail(int id)
        {
            var trainingArea = await _dispatcher.QueryAsync<GetTrainingArea, TrainingAreaDetailViewModel>(new GetTrainingArea { Id = id });
            
            return new JsonResult(trainingArea);
        }
    }
}