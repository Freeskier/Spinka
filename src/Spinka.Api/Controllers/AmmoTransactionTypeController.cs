using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.AmmoTransactionTypes.Queries;
using Spinka.Application.AmmoTransactionTypes.ViewModels;
using Spinka.Application.Dispatchers;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmmoTransactionTypeController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AmmoTransactionTypeController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmmoTransactionTypeViewModel>>> GetAll()
        {
            var ammoTransactionType = await _dispatcher.QueryAsync<GetAmmoTransactionTypes, IEnumerable<AmmoTransactionTypeViewModel>>(new GetAmmoTransactionTypes());
            
            return new JsonResult(ammoTransactionType);
        }
    }
}