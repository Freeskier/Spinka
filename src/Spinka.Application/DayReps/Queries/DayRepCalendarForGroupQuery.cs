using Spinka.Application.Dispatchers.Queries;
using Spinka.Domain.Models.ProcedureModels;
using System;
using System.Collections.Generic;

namespace Spinka.Application.DayReps.Queries
{
    public class DayRepCalendarForGroupQuery : IQuery<IEnumerable<DayRepCalendarForGroupProcedure>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GroupId { get; set; }
    }
}
