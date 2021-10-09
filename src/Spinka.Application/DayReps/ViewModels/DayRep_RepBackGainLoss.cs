using System.Collections.Generic;

namespace Spinka.Application.DayReps.ViewModels
{
    public class DayRep_RepBackGainLoss

    {
        public string DayRepAccr { get; set; }

        public List<string> ListOpNo { get; set; }

        public DayRep_RepBackGainLoss()
        {
            ListOpNo = new List<string>();
        }
    }
}
