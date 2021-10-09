using System.Collections.Generic;
using Spinka.Application.AssignedTrainingFacilities.ViewModels;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.AssignedTrainingFacilities.Queries
{
    public class GetAssignedTrainingFacilities : IQuery<IEnumerable<AssignedTrainingFacilitiesViewModel>> { }
}