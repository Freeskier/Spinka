using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;
using System.Collections.Generic;

namespace Spinka.Application.GroupForDayReps.Queries
{
    public class PersonsForDropdownQuery: IQuery<IEnumerable<PersonsForDropdownViewModel>>
    {
        public int DayRepGroupId { get; set; }


    }
}
