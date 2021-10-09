using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using System;
using System.Collections.Generic;

namespace Spinka.Application.DayReps.Queries
{
    public class DayRep_RepQuery: IQuery<List<DayRep_RepViewModel>>
    {
        public int GroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FullNameRenderingPersonId { get; set; }
        public int FullNameSigningPersonId { get; set; }

    }
}
