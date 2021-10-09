using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingFacilities.ViewModels;

namespace Spinka.Application.TrainingFacilities.Queries
{
    public class GetTrainingFacilities : IQuery<IEnumerable<TrainingFacilityViewModel>> { }
}