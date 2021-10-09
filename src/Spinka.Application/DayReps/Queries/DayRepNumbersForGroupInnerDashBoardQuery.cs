using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Domain.Models.ProcedureModels;
using System;
using System.Collections.Generic;


namespace Spinka.Application.DayReps.Queries
{
    public class DayRepNumbersForGroupInnerDashBoardQuery :IQuery<IEnumerable<DayRepNumbersForGroupInnerDashBoardProcedure>>
    {
        public DateTime Day { get; set; }
        public int DayRepGroupId { get; set; }
    }
}
