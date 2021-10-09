using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingLogs.ViewModels;
using Spinka.Domain.Models;

namespace Spinka.Application.TrainingLogs.Queries
{
    public class GetTrainingLogByEduBlock : IQuery<IEnumerable<TrainingLogByEduBlockViewModel>>
    {
        public int EduBlockId { get; set; }

        public GetTrainingLogByEduBlock(int id)
        {
            EduBlockId = id;
        }
    }
}