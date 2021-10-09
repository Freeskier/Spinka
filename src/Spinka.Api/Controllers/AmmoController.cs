using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spinka.Api.Attributes;
using Spinka.Application.Ammo.Queries;
using Spinka.Application.Ammo.ViewModels;
using Spinka.Application.Dispatchers;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmmoController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AmmoController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        } 
        
        //[ClaimRequirement(ClaimTypes.Role, "Ammo.R")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmmoViewModel>>> GetAll()
        {
            var ammo = await _dispatcher.QueryAsync<GetAmmo, IEnumerable<AmmoViewModel>>(new GetAmmo());
            
            return new JsonResult(ammo);
        }
        //[ClaimRequirement(ClaimTypes.Role, "Amunicja.S")]
        [HttpGet("{groupId}")]
        public async Task<ActionResult<IEnumerable<AmmoDetailViewModel>>> GetDetail(int groupId)
        {
            var ammo = await _dispatcher.QueryAsync<GetLimitAmmo, IEnumerable<AmmoDetailViewModel>>(new GetLimitAmmo { GroupId = groupId});
            
            return new JsonResult(ammo);
        }
    }
}