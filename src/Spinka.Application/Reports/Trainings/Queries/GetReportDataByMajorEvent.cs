using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Reports.Trainings.ViewModels;

namespace Spinka.Application.Reports.Trainings.Queries.Handlers
{
    public class GetReportDataByMajorEvent : IQuery<IEnumerable<TrainingReportViewModel>>
    {
        public GetReportDataByMajorEvent()
        {
        }
        public GetReportDataByMajorEvent(int id)
        {
            MajorId = id;
        }
        public int MajorId { get; set; }
    }
}