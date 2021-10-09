using System;
using System.Collections.Generic;

namespace Spinka.Application.EduBlocks.ViewModels
{
    public class EduBlockDetailViewModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public string Instructor { get; set; }
        public int InstructorId { get; set; }
        public string AmmoManager { get; set; }
        public int AmmoManagerId { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public string LastUpdatePersonEduBlock { get; set; }
        public int LastUpdatePersonEduBlockId { get; set; }
        public string CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public string Driver1 { get; set; }
        public int Driver1Id { get; set; }
        public string Driver2 { get; set; }
        public int Driver2Id { get; set; }
        public string ShootingInstructor { get; set; }
        public int ShootingInstructorId { get; set; }
        public string ExplosivesManager { get; set; }
        public int ExplosivesManagerId { get; set; }
        public string SecurityPerson { get; set; }
        public int SecurityPersonId { get; set; }
        
        public bool Approved { get; set; }
        public bool IsCancelled { get; set; }
        public string CancellReason { get; set; }
        public string ApprovedBy { get; set; }
        public int ApprovedById { get; set; }
        public DateTime? ApprovedTime { get; set; }
        public bool IsMedicalServiceRequired { get; set; }
        public string TrainingArea { get; set; }
        public string TrainingAreaId { get; set; }
        public string TrainingAcronym { get; set; }
        public string EduBlockSubject { get; set; }
        public int EduBlockSubjectId { get; set; }
        public string TrainingFacility { get; set; }
        public string AdditionalInformation { get; set; }
        public IEnumerable<AuxPersonForEduBlockViewModel> AuxPersons { get; set; }
        public IEnumerable<AssignedTrainingGroupToEduBlockViewModel> AssignedTrainingGroups { get; set; }
        public IEnumerable<AssignedTrainingFacilityToEduBlockViewModel> AssignedTrainingFacilities { get; set; }
        public IEnumerable<AssignedVehicleToEduBlockViewModel> AssignedVehicles { get; set; }
        public IEnumerable<AssignedAmmoToEduBlockViewModel> AssignedAmmo { get; set; }
        public IEnumerable<AssignedAssistantInstructorToEduBlockViewModel> AssignedAssistantInstructors { get; set; }
    }
}