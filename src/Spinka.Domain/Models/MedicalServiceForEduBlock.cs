using System.Collections.Generic;
using Spinka.Domain.Models.Enums;

namespace Spinka.Domain.Models
{
    public class MedicalServiceForEduBlock : BaseEntity
    {
        public int DriverPersonId { get; set; }
        
        public MedicalServiceType MedicalServiceType { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public int AmbulanceVehicleId { get; set; }
        public virtual EduBlock EduBlock { get; set; }
        
        private readonly ISet<AssignedPersonToMedicalService> _medicalStaff = new HashSet<AssignedPersonToMedicalService>();
        public IEnumerable<AssignedPersonToMedicalService> MedicalStaff => _medicalStaff;
    }
}