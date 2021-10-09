using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class TrainingFacility : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        private ISet<AssignedTrainingFacility> _assignedTrainingFacilities = new HashSet<AssignedTrainingFacility>();
        public IEnumerable<AssignedTrainingFacility> AssignedTrainingFacilities => _assignedTrainingFacilities;
    }
}