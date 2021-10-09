using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingGroups.ViewModels;

namespace Spinka.Application.TrainingGroups.Queries
{
    public class GetTrainingGroupForManagement : IQuery<TrainingGroupForManagementViewModel>
    {
        public int GroupId { get; set; }
    }
}