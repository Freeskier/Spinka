using System.Collections.Generic;

namespace Spinka.Application.DayReps.ViewModels
{
    public class DayRepDataForCalendarViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int PersonId { get; set; }
        public string Person { get; set; }
        public IEnumerable<DayRepViewModel> DayReps { get; set; }
    }
}
