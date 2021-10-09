using Spinka.Application.AssignedTrainingFacilities.ViewModels;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.AssignedTrainingFacilities.Queries
{
    public class GetAssignedTrainingFacility : IQuery<AssignedTrainingFacilitiesViewModel>
    {
        public int Id { get; set; }
    }
}