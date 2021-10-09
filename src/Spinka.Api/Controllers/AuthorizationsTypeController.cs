using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.AuthorizationsTypes.Queries;
using Spinka.Application.AuthorizationsTypes.Queries.Handlers;
using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Dispatchers;
using Spinka.Domain.Models;

namespace Spinka.Api.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationsTypeController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AuthorizationsTypeController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }


        


    }
}