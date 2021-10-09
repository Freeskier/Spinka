using System;
using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class DayRep : BaseEntity
    {
        public DateTime Day { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Login { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual DayRepAcronym DayRepAcronym { get; set; }
        public int? DayRepAcronymId { get; set; }

        public virtual DayRepGroupPerson DayRepGroupPerson { get; set; }
        public int DayRepGroupPersonId { get; set; }
        
        private ISet<AssignedAvailabilityType> _assignedAvailabilityTypes = new HashSet<AssignedAvailabilityType>();
        public IEnumerable<AssignedAvailabilityType> AssignedAvailabilityTypes => _assignedAvailabilityTypes;
    }
}