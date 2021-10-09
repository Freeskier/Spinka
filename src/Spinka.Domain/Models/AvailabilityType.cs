using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class AvailabilityType : BaseEntity
    {
        public string Type { get; set; }
        
        private ISet<AssignedAvailabilityType> _assignedAvailabilityTypes = new HashSet<AssignedAvailabilityType>();
        public IEnumerable<AssignedAvailabilityType> AssignedAvailabilityTypes => _assignedAvailabilityTypes;
    }
}