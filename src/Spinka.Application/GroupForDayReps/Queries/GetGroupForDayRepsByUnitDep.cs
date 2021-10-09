using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;

namespace Spinka.Application.GroupForDayReps.Queries
{
    public class GetGroupForDayRepsByUnitDep : IQuery<IEnumerable<GetGroupForDayRepByUnitDepViewModel>>
    {
        public int UnitDepId { get; set; }

        public GetGroupForDayRepsByUnitDep(int id)
        {
            UnitDepId = id;
        }
    }
}