using System;
using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class EduBlock : BaseEntity
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
        public virtual EduBlockSubject EduBlockSubject { get; set; }
        public int EduBlockSubjectId { get; set; }
        public virtual MedicalServiceForEduBlock MedicalServiceForEduBlock { get; set; }
        public int? MedicalServiceForEduBlockId { get; set; }
        public virtual MajorEvent MajorEvent { get; set; }
        public int? MajorEventId { get; set; }
        public bool IsCancelled { get; set; }
        public string CancellReason { get; set; }
        private readonly ISet<AssignedTrainingGroup> _assignedTrainingGroups = new HashSet<AssignedTrainingGroup>();
        public IEnumerable<AssignedTrainingGroup> AssignedTrainingGroups => _assignedTrainingGroups;
        private ISet<AssignedTrainingFacility> _assignedTrainingFacilities = new HashSet<AssignedTrainingFacility>();
        public IEnumerable<AssignedTrainingFacility> AssignedTrainingFacilities => _assignedTrainingFacilities;
        private ISet<AssignedVehicle> _assignedVehicles = new HashSet<AssignedVehicle>();
        public IEnumerable<AssignedVehicle> AssignedVehicles => _assignedVehicles;
        private ISet<AssignedAmmo> _assignedAmmo = new HashSet<AssignedAmmo>();
        public IEnumerable<AssignedAmmo> AssignedAmmo => _assignedAmmo;
        private ISet<AuxPersonForEduBlock> _auxPersons = new HashSet<AuxPersonForEduBlock>();
        public IEnumerable<AuxPersonForEduBlock> AuxPersons => _auxPersons;
        private ISet<AssignedAssistantInstructor> _assistantInstructors = new HashSet<AssignedAssistantInstructor>();
        public IEnumerable<AssignedAssistantInstructor> AssistantInstructors => _assistantInstructors;
        private ISet<EduBlockControl> _eduBlockControls = new HashSet<EduBlockControl>();
        public IEnumerable<EduBlockControl> EduBlockControls => _eduBlockControls;
        private ISet<AdditionalPersonnel> _additionalPersonnel = new HashSet<AdditionalPersonnel>();
        public IEnumerable<AdditionalPersonnel> AdditionalPersonnel => _additionalPersonnel;
    }
}