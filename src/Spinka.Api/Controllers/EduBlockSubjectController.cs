using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.EduBlockSubjects.Queries;
using Spinka.Application.EduBlockSubjects.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  EduBlockSubjectController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public EduBlockSubjectController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EduBlockSubjectViewModel>>> GetAll()
        {
            var trainingGroups = await _dispatcher.QueryAsync<GetEduBlockSubjects, IEnumerable<EduBlockSubjectViewModel>>(new GetEduBlockSubjects());
            
            return new JsonResult(trainingGroups);
        }
    }
}