using System;
using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingLogs.ViewModels;

namespace Spinka.Application.TrainingLogs.Queries
{
    public class GetTrainingLogByGroupWithEdu : IQuery<IEnumerable<TrainingLogByGroupWithEduViewModel>>
    {
        public int GroupId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}