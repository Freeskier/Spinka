using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.DayReps.Commands;
using Spinka.Application.DayReps.Queries;
using Spinka.Application.DayReps.ViewModels;
using Spinka.Domain.Models.ProcedureModels;
using System.Linq;
using Spinka.Application.GroupForDayReps.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayRepController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public DayRepController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("DayRepAcronym")]
        public async Task<ActionResult<IEnumerable<DayRepAcronymViewModel>>> GetAllAccronyms()
        {
            var dayRepAcronyms = await _dispatcher.QueryAsync<GetDayRepAcronyms, IEnumerable<DayRepAcronymViewModel>>(new GetDayRepAcronyms());

            return new JsonResult(dayRepAcronyms);
        }

        [HttpPost("DayRepDataForCalendar")] //wywalić i wstawić poniższe
        public async Task<ActionResult<IEnumerable<DayRepDataForCalendarViewModel>>> GetDataForCalendarForGroup([FromBody] DayRepDataForCalendarQuery command)
        {
            var dayRepAcronyms = await _dispatcher.QueryAsync<DayRepDataForCalendarQuery, IEnumerable<DayRepDataForCalendarViewModel>>(
                new DayRepDataForCalendarQuery
                {
                    DayRepGroupId = command.DayRepGroupId,
                    StartDate = command.StartDate,
                    EndDate = command.EndDate
                }
                );

            return new JsonResult(dayRepAcronyms);
        }

        [HttpPost("TestSqlCommand")]
        public async Task<ActionResult<IEnumerable<DayRepCalendarForGroupTextViewModel>>> GetDataForCalendar([FromBody] DayRepCalendarForGroupQuery command)
        {
            var dayRepAcronyms = await _dispatcher.QueryAsync<DayRepCalendarForGroupQuery, IEnumerable<DayRepCalendarForGroupProcedure>>(
                new DayRepCalendarForGroupQuery
                {
                    StartDate = command.StartDate,
                    EndDate = command.EndDate,
                    GroupId = command.GroupId,
                }
                );

            var auxInfo = await _dispatcher.QueryAsync<DayRepCalendarForGroupTextQuery, IEnumerable<DayRepCalendarForGroupProcedureText>>(
                new DayRepCalendarForGroupTextQuery
                {
                    StartDate = command.StartDate,
                    EndDate = command.EndDate,
                    GroupId = command.GroupId,
                }
                );
            List<DayRepCalendarForGroupTextViewModel> result = new List<DayRepCalendarForGroupTextViewModel>();
            for (int i = 0; i < dayRepAcronyms.Count(); i++)
            {
                result.Add(new DayRepCalendarForGroupTextViewModel
                {
                    Day1 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day1,
                        info = auxInfo.ElementAt(i).Day1
                    }),
                    Day2 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day2,
                        info = auxInfo.ElementAt(i).Day2,
                    }),
                    Day3 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day3,
                        info = auxInfo.ElementAt(i).Day3,
                    }),
                    Day4 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day4,
                        info = auxInfo.ElementAt(i).Day4,
                    }),
                    Day5 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day5,
                        info = auxInfo.ElementAt(i).Day5,
                    }),
                    Day6 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day6,
                        info = auxInfo.ElementAt(i).Day6,
                    }),
                    Day7 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day7,
                        info = auxInfo.ElementAt(i).Day7,
                    }),
                    Day8 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day8,
                        info = auxInfo.ElementAt(i).Day8,
                    }),
                    Day9 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day9,
                        info = auxInfo.ElementAt(i).Day9,
                    }),
                    Day10 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day10,
                        info = auxInfo.ElementAt(i).Day10,
                    }),
                    Day11 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day11,
                        info = auxInfo.ElementAt(i).Day11,
                    }),
                    Day12 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day12,
                        info = auxInfo.ElementAt(i).Day12,
                    }),
                    Day13 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day13,
                        info = auxInfo.ElementAt(i).Day13,
                    }),
                    Day14 = (new AuxDay
                    {
                        accrId = dayRepAcronyms.ElementAt(i).Day14,
                        info = auxInfo.ElementAt(i).Day14,
                    }),
                    FullName = dayRepAcronyms.ElementAt(i).FullName,
                    PersonInGroupId = dayRepAcronyms.ElementAt(i).PersonInGroupId
                });

            }

            return new JsonResult(result);
        }
        [HttpPost("GetAddDataForCalendar")]
        public async Task<ActionResult<IEnumerable<DayRepCalendarForGroupProcedureText>>> GetAddDataForCalendar([FromBody] DayRepCalendarForGroupTextQuery command)
        {
            var dayRepAcronyms = await _dispatcher.QueryAsync<DayRepCalendarForGroupTextQuery, IEnumerable<DayRepCalendarForGroupProcedureText>>(
                new DayRepCalendarForGroupTextQuery
                {
                    StartDate = command.StartDate,
                    EndDate = command.EndDate,
                    GroupId = command.GroupId,
                }
                );

            return new JsonResult(dayRepAcronyms);
        }

        [HttpPost("AddDayRepEntry")]
        public async Task<ActionResult> AddDayRepEntry([FromBody] AddEntries command)
        {
            await _dispatcher.SendAsync(command);

            return CreatedAtAction(null, null, null);
        }

        [HttpDelete("DeleteEntries")]
        public async Task<ActionResult> DeleteEntries([FromBody] DeleteDayRepEntry command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
        [HttpPost("GetDayReportForGroup")]
        public async Task<ActionResult<IEnumerable<DayRep_RepViewModel>>> GetDayReportForGroup([FromBody] DayRep_RepDBRequest command)
        {
            var result = await _dispatcher.QueryAsync<DayRep_RepQuery, List<DayRep_RepViewModel>>(new DayRep_RepQuery{ 
            
            StartDate=command.StartDate,
            EndDate=command.EndDate,
            FullNameSigningPersonId= command.FullNameSigningPersonId,
            FullNameRenderingPersonId=command.FullNameRenderingPersonId,
            GroupId=command.GroupID
            
            });

            return new JsonResult(result);
        }
        [HttpPost("GetDataForDayRepInnerDashBoard")]
        public async Task<ActionResult<IEnumerable<DayRepNumbersForGroupInnerDashBoardViewModel>>> GetDataForDayRepInnerDashBoard([FromBody] DayRepNumbersForGroupInnerDashBoardQuery query)
        {
           var dashboardata= await _dispatcher.QueryAsync<DayRepNumbersForGroupInnerDashBoardQuery,IEnumerable<DayRepNumbersForGroupInnerDashBoardProcedure>>(
               new DayRepNumbersForGroupInnerDashBoardQuery
            { 
             DayRepGroupId=query.DayRepGroupId,
             Day=query.Day.Date
            });

            return new JsonResult(dashboardata);
        } 
        
        [HttpPost("GetDayRepsByTrainingGroup")]
        public async Task<ActionResult<IEnumerable<GetDayRepsByTrainingGroupViewModel>>> GetDayRepsByTrainingGroup([FromBody] GetDayRepsByTrainingGroup query)
        {
           var result= await _dispatcher.QueryAsync<GetDayRepsByTrainingGroup,IEnumerable<GetDayRepsByTrainingGroupViewModel>>(
               new GetDayRepsByTrainingGroup
            { 
             TrainingGroupId= query.TrainingGroupId,
             Day=query.Day.Date
            });

            return new JsonResult(result);
        }
    }

}

