using System;
using System.Collections.Generic;
using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.DayReps.Queries
{
    public class GetDayRepsByTrainingGroup : IQuery<IEnumerable<GetDayRepsByTrainingGroupViewModel>>
    {
        public DateTime Day { get; set; }
        public int TrainingGroupId { get; set; }
    }
}