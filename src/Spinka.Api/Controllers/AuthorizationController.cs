using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Spinka.Application.AuthorizationsTypes.Commands;
using Spinka.Application.AuthorizationsTypes.Queries;
using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Dispatchers;
using Spinka.Application.Persons.Commands;

namespace Spinka.Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AuthorizationController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            
        }
        [Authorize(AuthenticationSchemes = "Windows")]
        [HttpGet("Login")]
        public async Task<ActionResult> Login()
        {
            return new OkResult();
        }
        
        [HttpPost("AddAuthorizationsTypeToPerson")]
        public async Task<ActionResult> AddPersonAuthorizationsType([FromBody] AddPersonAuthorizationsType command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }

        [HttpPut("DeleteAuthorizationsTypeFromPerson")]
        public async Task<ActionResult> DeletePersonAuthorizationsType(
            [FromBody] DeletePersonAuthorizationsType command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(null, null, null);
        }
        
        [HttpGet("GetAllAuthorizationsTypes")]
        public async Task<ActionResult<IEnumerable<AuthorizationsTypeViewModel>>> GetAllAuthorizationsTypes()
        {
            var authorizationsTypes = await _dispatcher
                .QueryAsync<GetAllAuthorizationsTypes, IEnumerable<AuthorizationsTypeViewModel>>(new GetAllAuthorizationsTypes());
            return new JsonResult(authorizationsTypes);
        }
        
        [HttpGet("AuthorizationType/{id}/Permissions")]
        public async Task<ActionResult<IEnumerable<AuthorizationsTypePermissionViewModel>>>
            GetAuthorizationsTypePermissions(int id)
        {
            var permissions =  await _dispatcher
                .QueryAsync<GetAuthorizationsTypePermissions, IEnumerable<AuthorizationsTypePermissionViewModel>>(
                    new GetAuthorizationsTypePermissions{ AuthorizationTypeId = id});
            return new JsonResult(permissions);
        }

        [HttpPut("DeleteAuthorizationsType")]
        public async Task<ActionResult> DeleteAuthorizationsType(DeleteAuthorizationsType command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(null, null, null);
        }
        
        [HttpPost("CreateAuthorizationsType")]
        public async Task<ActionResult> CreateAuthorizationsType(CreateAuthorizationsType command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(null, null, null);
        }
    }
}