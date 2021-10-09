using System;
using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Reports.Trainings.ViewModels;

namespace Spinka.Application.Reports.Trainings.Queries
{
    public class GetDataForTrainingReport : IQuery<IEnumerable<TrainingReportViewModel>>
    {
        public int UnitDepartmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
    }
}