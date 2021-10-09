using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingGroups.ViewModels;

namespace Spinka.Application.TrainingGroups.Queries
{
    public class GetTrainingGroup : IQuery<TrainingGroupDetailViewModel>
    {
        public int Id { get; set; }
    }
}