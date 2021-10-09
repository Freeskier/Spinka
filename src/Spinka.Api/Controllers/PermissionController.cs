using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.Permissions.Queries;
using Spinka.Application.Permissions.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController
    {
        private readonly IDispatcher _dispatcher;

        public PermissionController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionViewModel>>> GetAllPermissions()
        {
            var permissions = await _dispatcher.QueryAsync<GetAllPermissions, IEnumerable<PermissionViewModel>>(new GetAllPermissions());
            return new JsonResult(permissions);
        }

        [HttpGet("Person/{personId}")]
        public async Task<ActionResult<IEnumerable<PermissionViewModel>>> GetPersonpermissions(int personId)
        {
            var permissions = await _dispatcher.QueryAsync<GetPersonPermissions, IEnumerable<PermissionViewModel>>
                (new GetPersonPermissions {PersonId = personId});
            return new JsonResult(permissions);
        }
    }
}