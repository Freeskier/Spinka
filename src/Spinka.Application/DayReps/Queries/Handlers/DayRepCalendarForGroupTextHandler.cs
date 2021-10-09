using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Domain.Models;
using Spinka.Domain.Models.ProcedureModels;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinka.Application.DayReps.Queries.Handlers
{
    public class DayRepCalendarForGroupTextHandler : IQueryHandler<DayRepCalendarForGroupTextQuery, IEnumerable<DayRepCalendarForGroupProcedureText>>
    {
        private readonly IRepositoryHelper<DayRepCalendarForGroupProcedureText> _helper;

        public DayRepCalendarForGroupTextHandler(IRepositoryHelper<DayRepCalendarForGroupProcedureText> helper)
        {
            _helper = helper;
        }


        public async Task<IEnumerable<DayRepCalendarForGroupProcedureText>> HandleAsync(DayRepCalendarForGroupTextQuery query)
        {
            var tmp = new List<object>
            {
                query.StartDate,
                query.EndDate,
                query.GroupId
            };
            return await _helper.ExecuteSqlProcedureToSingleResult("P_GetDataForDayRepsGroupText", tmp, "@StartDate", "@EndDate", "@GroupId");
        }
    }
    
}
