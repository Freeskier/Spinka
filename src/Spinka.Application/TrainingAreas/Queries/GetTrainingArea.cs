using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingAreas.ViewModels;

namespace Spinka.Application.TrainingAreas.Queries
{
    public class GetTrainingArea : IQuery<TrainingAreaDetailViewModel>
    {
        public int Id { get; set; }
    }
}