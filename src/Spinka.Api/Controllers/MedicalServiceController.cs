using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.MedicalServiceForEduBlocks.Commands;
using Spinka.Application.MedicalServiceForEduBlocks.Queries;
using Spinka.Application.MedicalServiceForEduBlocks.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalServiceController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public MedicalServiceController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("EduBlock/{eduBlockId}")]
        public async Task<ActionResult<MedicalServiceForEduBlockViewModel>> GetMedicalService(int eduBlockId)
        {
            var medicalService = await _dispatcher.QueryAsync<GetMedicalService, MedicalServiceForEduBlockViewModel>(
                    new GetMedicalService { EduBlockId = eduBlockId });

            return new JsonResult(medicalService);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateMedicalService([FromBody] CreateMedicalService command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateMedicalService([FromBody] UpdateMedicalService command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}