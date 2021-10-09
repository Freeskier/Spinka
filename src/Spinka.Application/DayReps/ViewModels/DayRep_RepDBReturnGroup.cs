using System;
using System.Collections.Generic;

namespace Spinka.Application.DayReps.ViewModels
{
    public class DayRep_RepDBReturnGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string FullNameRendering { get; set; }
        public string FullNameSigning { get; set; }
        public DateTime Day { get; set; }
        public List<DayRep_RepDBReturnSingle> ListOfDayRep_RepDBReturnSingles { get; set; }

        public DayRep_RepDBReturnGroup()
        {
            ListOfDayRep_RepDBReturnSingles = new List<DayRep_RepDBReturnSingle>();
        }

    }
}
