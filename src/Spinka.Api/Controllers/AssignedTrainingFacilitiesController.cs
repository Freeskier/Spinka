using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.AssignedTrainingFacilities.Commands;
using Spinka.Application.AssignedTrainingFacilities.Queries;
using Spinka.Application.AssignedTrainingFacilities.ViewModels;
using Spinka.Application.Dispatchers;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedTrainingFacilitiesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AssignedTrainingFacilitiesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignedTrainingFacilitiesViewModel>>> GetAll()
        {
            var assignedTrainingFacilities = await _dispatcher.QueryAsync<GetAssignedTrainingFacilities, IEnumerable<AssignedTrainingFacilitiesViewModel>>(new GetAssignedTrainingFacilities());
            
            return new JsonResult(assignedTrainingFacilities);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AssignedTrainingFacilitiesViewModel>>> Get(int id)
        {
            var assignedTrainingFacility = await _dispatcher.QueryAsync<GetAssignedTrainingFacility, AssignedTrainingFacilitiesViewModel>(new GetAssignedTrainingFacility { Id = id });
            
            return new JsonResult(assignedTrainingFacility);
        }
        
        // [HttpPut]
        // public async Task<ActionResult> EditTrainingFacilities([FromBody] ChangeTrainingFacilities command)
        // {
        //     await _dispatcher.SendAsync(command);
        //
        //     return NoContent();
        // }
        
        [HttpPut]
        public async Task<ActionResult> EditTrainingFacilities([FromBody] ChangeTrainingFacilityOnlyOneObject command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}