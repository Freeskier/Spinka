using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Api.Attributes;
using Spinka.Application.Dispatchers;
using Spinka.Application.Persons.Commands;
using Spinka.Application.Persons.Queries;
using Spinka.Application.Persons.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public PersonController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetAll()
        {
            var persons = await _dispatcher.QueryAsync<GetPersons, IEnumerable<PersonViewModel>>(new GetPersons());
            
            return new JsonResult(persons);
        }

        [HttpGet("{login}")]
        public async Task<ActionResult<PersonByLoginViewModel>> GetPersonByLogin(string login)
        {
            var person = await _dispatcher.QueryAsync<GetPersonByLogin, PersonByLoginViewModel>(new GetPersonByLogin{Login = login});
            return new JsonResult(person);
        }
        
        [HttpGet("Soldiers")]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetSoldiers()
        {
            var persons = await _dispatcher.QueryAsync<GetPersonsWithoutCivilians, IEnumerable<PersonViewModel>>(new GetPersonsWithoutCivilians());
            
            return new JsonResult(persons);
        }
        
        [HttpGet("MedicalStaff")]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetMedicalStaff()
        {
            var persons = await _dispatcher.QueryAsync<GetMedicalStaff, IEnumerable<PersonViewModel>>(new GetMedicalStaff());
            
            return new JsonResult(persons);
        }
        
        [HttpPost("Pattern")]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetPersonWithPattern([FromBody] GetPersonWithPattern query)
        {
            var persons = await _dispatcher.QueryAsync<GetPersonWithPattern, IEnumerable<PersonViewModel>>(
                new GetPersonWithPattern
                {
                    Pattern = query.Pattern,
                    Ids = query.Ids
                });
            
            return new JsonResult(persons);
        }
       
        [HttpPost]
        public async Task<ActionResult> CreatePerson([FromBody] CreatePerson command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }
        
        [HttpGet("{userId}/AuthorizationsTypes")]
        public async Task<ActionResult<IEnumerable<PersonAuthorizationsTypeViewModel>>> GetUserAuthorizationsTypes(int userId)
        {
            var userAuthorizationsTypes =
                await _dispatcher.QueryAsync<GetPersonAuthorizationsType,IEnumerable<PersonAuthorizationsTypeViewModel>>(new GetPersonAuthorizationsType
                    {UserId = userId});
            return new JsonResult(userAuthorizationsTypes);
        }
    }
}