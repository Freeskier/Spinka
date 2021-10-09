using System;
using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingLogs.ViewModels;

namespace Spinka.Application.TrainingLogs.Queries
{
    public class GetTrainingLogsByGroupId : IQuery<IEnumerable<TrainingLogByGroupIdViewModel>>
    {
        public int GroupId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public GetTrainingLogsByGroupId()
        {
            
        }
        public GetTrainingLogsByGroupId(int groupId, DateTime dateFrom, DateTime dateTo)
        {
            GroupId = groupId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

    }
}