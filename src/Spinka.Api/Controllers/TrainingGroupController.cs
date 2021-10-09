using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.TrainingGroups.Queries;
using Spinka.Application.TrainingGroups.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingGroupController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public TrainingGroupController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingGroupViewModel>>> GetAll()
        {
            var trainingGroups = await _dispatcher.QueryAsync<GetTrainingGroups, IEnumerable<TrainingGroupViewModel>>(new GetTrainingGroups());
            
            return new JsonResult(trainingGroups);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingGroupDetailViewModel>> GetDetail(int id)
        {
            var trainingGroup = await _dispatcher.QueryAsync<GetTrainingGroup, TrainingGroupDetailViewModel>(new GetTrainingGroup { Id = id });
            
            return new JsonResult(trainingGroup);
        }
        
        [HttpGet("Without/{id}")]
        public async Task<ActionResult<IEnumerable<TrainingGroupViewModel>>> GetWithout(int id)
        {
            var trainingGroups = await _dispatcher.QueryAsync<GetWithoutTrainingGroup, IEnumerable<TrainingGroupViewModel>>(new GetWithoutTrainingGroup { Id = id });
            
            return new JsonResult(trainingGroups);
        }
        
        [HttpGet("Management/{id}")]
        public async Task<ActionResult<TrainingGroupForManagementViewModel>> GetForManagement(int id)
        {
            var trainingGroup = await _dispatcher.QueryAsync<GetTrainingGroupForManagement, TrainingGroupForManagementViewModel>(new GetTrainingGroupForManagement { GroupId = id });
            
            return new JsonResult(trainingGroup);
        }
        
        [HttpGet("Person/{id}")]
        public async Task<ActionResult<IEnumerable<PersonForManagementViewModel>>> GetPersonForManagement(int id)
        {
            var persons = await _dispatcher.QueryAsync<GetPersonForManagement, IEnumerable<PersonForManagementViewModel>>(new GetPersonForManagement() { GroupId = id });
            
            return new JsonResult(persons);
        }
    }
}