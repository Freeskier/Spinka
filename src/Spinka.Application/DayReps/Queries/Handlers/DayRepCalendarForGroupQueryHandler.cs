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
    public class DayRepCalendarForGroupQueryHandler : IQueryHandler<DayRepCalendarForGroupQuery, IEnumerable<DayRepCalendarForGroupProcedure>>
    {
        private readonly IRepositoryHelper<DayRepCalendarForGroupProcedure> _helper;

        public DayRepCalendarForGroupQueryHandler(IRepositoryHelper<DayRepCalendarForGroupProcedure> helper)
        {
            _helper = helper;
        }

        public async Task<IEnumerable<DayRepCalendarForGroupProcedure>> HandleAsync(DayRepCalendarForGroupQuery query)

        {
            var tmp = new List<object>
            {
                query.StartDate,
                query.EndDate,
                query.GroupId
            };

            return await _helper.ExecuteSqlProcedureToSingleResult("P_GetDataForDayRepsGroup", tmp, "@StartDate", "@EndDate", "@GroupId");
        }
    }
}
