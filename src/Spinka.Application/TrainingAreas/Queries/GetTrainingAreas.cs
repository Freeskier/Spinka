using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingAreas.ViewModels;

namespace Spinka.Application.TrainingAreas.Queries
{
    public class GetTrainingAreas : IQuery<IEnumerable<TrainingAreaViewModel>> { }
}