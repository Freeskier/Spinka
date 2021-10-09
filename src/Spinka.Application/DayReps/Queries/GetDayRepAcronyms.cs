using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using System.Collections.Generic;

namespace Spinka.Application.DayReps.Queries
{
    public class GetDayRepAcronyms : IQuery<IEnumerable<DayRepAcronymViewModel>> { }
}
