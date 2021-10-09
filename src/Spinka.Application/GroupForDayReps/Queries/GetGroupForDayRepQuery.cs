using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;

namespace Spinka.Application.GroupForDayReps.Queries
{
    public class GetGroupForDayRepQuery: IQuery<GetGroupForDayRepViewModel>
    {
        public int DayRepGroupId { get; set; }
    }
}
