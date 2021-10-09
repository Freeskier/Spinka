using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using System;
using System.Collections.Generic;

namespace Spinka.Application.DayReps.Queries
{
    public class DayRepDataForCalendarQuery : IQuery<IEnumerable<DayRepDataForCalendarViewModel>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayRepGroupId { get; set; }
    }
    
    
}
