using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.Reports.Ammo.Queries;
using Spinka.Application.Reports.Ammo.ViewModels;
using Spinka.Application.Reports.OrderPoints.Commands;
using Spinka.Application.Reports.Trainings.Queries;
using Spinka.Application.Reports.Trainings.Queries.Handlers;
using Spinka.Application.Reports.Trainings.ViewModels;

namespace Spinka.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public ReportsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpPost("Training")]
        public async Task<ActionResult<IEnumerable<TrainingReportViewModel>>> GetDataForTrainingReport([FromBody] GetDataForTrainingReport query)
        {
            var dataForTrainingReport =
                await _dispatcher.QueryAsync<GetDataForTrainingReport, IEnumerable<TrainingReportViewModel>>(
                    new GetDataForTrainingReport
                    {
                        UnitDepartmentId = query.UnitDepartmentId,
                        StartTime = query.StartTime,
                        EndOn = query.EndOn
                    });

            return new JsonResult(dataForTrainingReport);
        }

        [HttpGet("Training/ByMajorEvent/{id}")]
        public async Task<ActionResult<IEnumerable<TrainingReportViewModel>>> GetReportDataByMajorEvent(int id)
        {
            var data = await _dispatcher.QueryAsync<GetReportDataByMajorEvent,
                IEnumerable<TrainingReportViewModel>>(new GetReportDataByMajorEvent(id));

            return new JsonResult(data);
        }
        
        [HttpPost("Ammo")]
        public async Task<ActionResult<AmmoReportViewModel>> GetDataForAmmoReport([FromBody] GetDataForAmmoReport query)
        {
            var dataForAmmoReport = await _dispatcher.QueryAsync<GetDataForAmmoReport, AmmoReportViewModel>(
                new GetDataForAmmoReport
                {
                    EduBlockId = query.EduBlockId,
                    OrderNumber = query.OrderNumber,
                    OrderDate = query.OrderDate
                });

            return new JsonResult(dataForAmmoReport);
        }

        // [HttpPost]
        // public async Task<ActionResult> CreateTrainingReport([FromBody] CreateTrainingReport command)
        // {
        //     await _dispatcher.SendAsync(command);
        //
        //     return CreatedAtAction(null, null, null);
        // }
        
        [HttpPost("Order")]
        public async Task<ActionResult> CreateOrderPoint([FromBody] CreateOrder command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }
        
        // [HttpPost("Ammo")]
        // public async Task<ActionResult> CreateAmmoReport([FromBody] CreateAmmoReport command)
        // {
        //     await _dispatcher.SendAsync(command);
        //
        //     return CreatedAtAction(null, null, null);
        // }
    }
}