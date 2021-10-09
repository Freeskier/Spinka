using System;

namespace Spinka.Domain.Models
{
    public class AssignedAvailabilityType : BaseEntity
    {
        public DateTime LastUpdate { get; set; }
        public string Login { get; set; }
        public int? AvailabilityRoleId { get; set; }

        public virtual DayRep DayRep { get; set; }
        public int DayRepId { get; set; }

        public virtual AvailabilityType AvailabilityType { get; set; }
        public int AvailabilityTypeId { get; set; }
    }
}