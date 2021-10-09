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
    public class DayRepNumbersForGroupInnerDashBoardQueryHandler : IQueryHandler<DayRepNumbersForGroupInnerDashBoardQuery, IEnumerable<DayRepNumbersForGroupInnerDashBoardProcedure>>
    {
        private readonly IRepositoryHelper<DayRepNumbersForGroupInnerDashBoardProcedure> _helper;

        public DayRepNumbersForGroupInnerDashBoardQueryHandler(IRepositoryHelper<DayRepNumbersForGroupInnerDashBoardProcedure> helper)
        {
            _helper = helper;
        }
        public async Task<IEnumerable<DayRepNumbersForGroupInnerDashBoardProcedure>> HandleAsync(DayRepNumbersForGroupInnerDashBoardQuery query)
        {
            var tmp = new List<object>
            {
                query.Day,
                query.DayRepGroupId,
            };

            return await _helper.ExecuteSqlProcedureToSingleResult("[P_DayRepNumbersForGroupInnerDashBoardProcedure]", tmp, "@Day", "@DayRepGroupId");
        }
    }
}
