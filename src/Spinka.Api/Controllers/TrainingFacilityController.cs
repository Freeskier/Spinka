using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.TrainingFacilities.Queries;
using Spinka.Application.TrainingFacilities.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingFacilityController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public TrainingFacilityController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingFacilityViewModel>>> GetAll()
        {
            var trainingFacilities = await _dispatcher.QueryAsync<GetTrainingFacilities, IEnumerable<TrainingFacilityViewModel>>(new GetTrainingFacilities());
            
            return new JsonResult(trainingFacilities);
        }
        
        [HttpGet("{location}")]
        public async Task<ActionResult<TrainingFacilityViewModel>> GetDetail(string location)
        {
            var trainingGroup = await _dispatcher.QueryAsync<GetTrainingFacilitiesByLocation, IEnumerable<TrainingFacilityViewModel>>(new GetTrainingFacilitiesByLocation { Location = location });
            
            return new JsonResult(trainingGroup);
        }
    }
}