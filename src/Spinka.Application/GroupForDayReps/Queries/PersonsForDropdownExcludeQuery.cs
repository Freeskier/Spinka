using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;
using System.Collections.Generic;

namespace Spinka.Application.GroupForDayReps.Queries
{
    public class PersonsForDropdownExcludeQuery: IQuery<IEnumerable<PersonsForDropdownViewModel>>
    {
        public int DayRepGroupId { get; set; }

        public string SearchString { get; set; }


    }
}
