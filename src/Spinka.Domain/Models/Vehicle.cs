using System.Collections.Generic;
using Spinka.Domain.Models.Enums;

namespace Spinka.Domain.Models
{
    public class Vehicle : BaseEntity
    {
        public string RegisterNumber { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public virtual MedicalServiceForEduBlock MedicalServiceForEduBlock { get; set; }
        private ISet<AssignedVehicle> _assignedVehicles = new HashSet<AssignedVehicle>();
        public IEnumerable<AssignedVehicle> AssignedVehicles => _assignedVehicles;
    }
}