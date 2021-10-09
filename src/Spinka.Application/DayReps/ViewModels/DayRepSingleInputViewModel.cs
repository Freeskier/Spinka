using System;

namespace Spinka.Application.DayReps.ViewModels
{
    public class DayRepSingleInputViewModel
    {
        public int PersonInGroupForDayRepIdViewModel { get; set; }
        public int AccrId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
