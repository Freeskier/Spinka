using System;

namespace Spinka.Domain.Models
{
    public class EduBlockHistory : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public Guid ModifyGuid { get; set; }
        public int InstructorPersonId { get; set; }
        public int? AmmoManagerPersonId { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public int LastUpdatePersonId { get; set; }
        public int CreatedByPersonId { get; set; }
        public int? DriverPersonId1 { get; set; }
        public int? DriverPersonId2 { get; set; }
        public int? ShootingInstructorPersonId { get; set; }
        public int? ExplosivesManagerPersonId { get; set; }
        public int? SecurityPersonId { get; set; }
        public bool Approved { get; set; }
        public int? ApprovedByPersonId { get; set; }
        public DateTime? ApprovedTime { get; set; }
        public string TrainingFacility { get; set; }
        public string CancellingRemarks { get; set; }
        public bool IsMedicalServiceRequired { get; set; }
        public string AdditionalInformation { get; set; }
        public int EduBlockSubjectId { get; set; }
        public int? MedicalServiceForEduBlockId { get; set; }
        public int? MajorEventId { get; set; }
    }
}