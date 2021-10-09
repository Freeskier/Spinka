using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Application.GroupForDayReps.Queries;
using Spinka.Application.GroupForDayReps.Commands;
using Spinka.Application.DayReps.Queries;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupForDayRepController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public GroupForDayRepController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;

        }
        [HttpGet("GetGroupForDayRep/{groupId}")]
        public async Task<ActionResult<GetGroupForDayRepViewModel>> GetGroupForDayRep(int groupId)
        {
            var dayRepAcronyms = await _dispatcher.QueryAsync<GetGroupForDayRepQuery, GetGroupForDayRepViewModel>(new GetGroupForDayRepQuery
            {
                DayRepGroupId = groupId

            });

            return new JsonResult(dayRepAcronyms);
        }
        [HttpGet("GetPersonsForDropdown/{groupId}")]
        public async Task<ActionResult<GetGroupForDayRepViewModel>> GetPersonsForDropdown(int groupId)
        {
            var personsForDropdown = await _dispatcher.QueryAsync<PersonsForDropdownQuery, IEnumerable<PersonsForDropdownViewModel>>(new PersonsForDropdownQuery
            {
                DayRepGroupId = groupId
            });

            return new JsonResult(personsForDropdown);
        }
        [HttpGet("GetAllGroups")]
        public async Task<ActionResult<GetGroupForDayRepViewModel>> GetAllGroups()
        {
            var groupsForDropdown = await _dispatcher.QueryAsync<GetAllGroupsQuery, IEnumerable<GetAllGroupsViewModel>>(new GetAllGroupsQuery());

            return new JsonResult(groupsForDropdown);
        }
        [HttpPost("AddPersonToGroup")]
        public async Task<ActionResult> AddPersonToGroup([FromBody] AddPersonToGroupForDayRepCommand command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
        [HttpPost("DeletePersonFromGroup")]
        public async Task<ActionResult> DeletePersonFromGroup([FromBody] DeletePersonFromGroupCommand command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }

        [HttpGet("GetGroupForDayRepsByUnitDep/{id}")]
        public async Task<IEnumerable<GetGroupForDayRepByUnitDepViewModel>> GetGroupForDayRepsByUnitDep(int id)
        {
            var result = await _dispatcher.QueryAsync<GetGroupForDayRepsByUnitDep
                ,IEnumerable<GetGroupForDayRepByUnitDepViewModel>>(new GetGroupForDayRepsByUnitDep(id));
            return result;
        }

    }
}
