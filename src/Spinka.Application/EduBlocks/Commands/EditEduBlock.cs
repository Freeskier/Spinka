using System;
using System.Collections.Generic;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.EduBlocks.Utils;

namespace Spinka.Application.EduBlocks.Commands
{
    public class EditEduBlock : ICommand
    {
        // public int Id { get; set; }
        // public IEnumerable<AssignedTrainingGroup> AssignedTrainingGroups { get; set; }
        // public DateTime StartTime { get; set; }
        // public DateTime EndOn { get; set; }
        // public int EduBlockSubjectId { get; set; }
        // public IEnumerable<AssignedTrainingFacility> AssignedTrainingFacilities { get; set; }
        // public int InstructorPersonId { get; set; }
        // public int? ShootingInstructorPersonId { get; set; }
        // public int? AmmoManagerPersonId { get; set; }
        // public int? DriverPersonId1 { get; set; }
        // public int? DriverPersonId2 { get; set; }
        // public int? SecurityPersonId { get; set; }
        // public IEnumerable<AssignedVehicle> AssignedVehicles { get; set; }
        // public int? ExplosivesManagerPersonId { get; set; }
        // public IEnumerable<AuxPersonForEduBlock> AuxPersons { get; set; }
        // public int LastUpdatePersonId { get; set; }
        // public string TrainingFacility { get; set; }
        // public bool IsMedicalServiceRequired { get; set; }
        //
        // public int EduBlockId { get; set; }
        //
        // public EditEduBlock() { }
        //
        // public EditEduBlock(int id, IEnumerable<AssignedTrainingGroup> assignedTrainingGroups, DateTime startTime, 
        //     DateTime endOn, int eduBlockSubjectId, IEnumerable<AssignedTrainingFacility> assignedTrainingFacilities, 
        //     int instructorPersonId, int? shootingInstructorPersonId, int? ammoManagerPersonId, int? driverPersonId1, 
        //     int? driverPersonId2, int? securityPersonId,IEnumerable<AssignedVehicle> assignedVehicles, int? explosivesManagerPersonId, 
        //     IEnumerable<AuxPersonForEduBlock> auxPersons, int lastUpdatePersonId, string trainingFacility,
        //     bool isMedicalServiceRequired)
        // {
        //     Id = id;
        //     AssignedTrainingGroups = assignedTrainingGroups;
        //     StartTime = startTime;
        //     EndOn = endOn;
        //     EduBlockSubjectId = eduBlockSubjectId;
        //     AssignedTrainingFacilities = assignedTrainingFacilities;
        //     InstructorPersonId = instructorPersonId;
        //     ShootingInstructorPersonId = shootingInstructorPersonId;
        //     AmmoManagerPersonId = ammoManagerPersonId;
        //     DriverPersonId1 = driverPersonId1;
        //     DriverPersonId2 = driverPersonId2;
        //     SecurityPersonId = securityPersonId;
        //     AssignedVehicles = assignedVehicles;
        //     ExplosivesManagerPersonId = explosivesManagerPersonId;
        //     AuxPersons = auxPersons;
        //     LastUpdatePersonId = lastUpdatePersonId;
        //     TrainingFacility = trainingFacility;
        //     IsMedicalServiceRequired = isMedicalServiceRequired;
        // }
        
        public int Id { get; set; }
        public IEnumerable<IdRequestModel> AssignedTrainingGroups { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public int EduBlockSubjectId { get; set; }
        public IEnumerable<TrainingFacilityRequestModel> AssignedTrainingFacilities { get; set; }
        public int InstructorPersonId { get; set; }
        public int? ShootingInstructorPersonId { get; set; }
        public int? AmmoManagerPersonId { get; set; }
        public int? DriverPersonId1 { get; set; }
        public int? DriverPersonId2 { get; set; }
        public IEnumerable<IdRequestModel> AssignedVehicles { get; set; }
        public int? ExplosivesManagerPersonId { get; set; }
        public int? SecurityPersonId { get; set; }
        public IEnumerable<IdRequestModel> AuxPersons { get; set; }
        public IEnumerable<IdRequestModel> AssistantInstructors { get; set; }
        public IEnumerable<IdRequestModel> AdditionalPersonnel { get; set; }
        public int LastUpdatePersonId { get; set; }
        public int CreatedByPersonId { get; set; }
        public string TrainingFacility { get; set; }
        public bool IsMedicalServiceRequired { get; set; }
        public string AdditionalInformation { get; set; }
        
        public int EduBlockId { get; set; }
        
        public EditEduBlock() { }

        public EditEduBlock(int id, IEnumerable<IdRequestModel> assignedTrainingGroups, DateTime startTime, DateTime endOn, 
            int eduBlockSubjectId, IEnumerable<TrainingFacilityRequestModel> assignedTrainingFacilities, int instructorPersonId, 
            int? shootingInstructorPersonId, int? ammoManagerPersonId, int? driverPersonId1, int? driverPersonId2, int? securityPersonId,
            IEnumerable<IdRequestModel> assignedVehicles, int? explosivesManagerPersonId, IEnumerable<IdRequestModel> auxPersons,
            IEnumerable<IdRequestModel> assistantInstructors, IEnumerable<IdRequestModel> additionalPersonnel, int lastUpdatePersonId, 
            int createdByPersonId, string trainingFacility, bool isMedicalServiceRequired, string additionalInformation)
        {
            Id = id;
            AssignedTrainingGroups = assignedTrainingGroups;
            StartTime = startTime;
            EndOn = endOn;
            EduBlockSubjectId = eduBlockSubjectId;
            AssignedTrainingFacilities = assignedTrainingFacilities;
            InstructorPersonId = instructorPersonId;
            ShootingInstructorPersonId = shootingInstructorPersonId;
            AmmoManagerPersonId = ammoManagerPersonId;
            DriverPersonId1 = driverPersonId1;
            DriverPersonId2 = driverPersonId2;
            AssignedVehicles = assignedVehicles;
            ExplosivesManagerPersonId = explosivesManagerPersonId;
            SecurityPersonId = securityPersonId;
            AuxPersons = auxPersons;
            AssistantInstructors = assistantInstructors;
            AdditionalPersonnel = additionalPersonnel;
            LastUpdatePersonId = lastUpdatePersonId;
            CreatedByPersonId = createdByPersonId;
            TrainingFacility = trainingFacility;
            IsMedicalServiceRequired = isMedicalServiceRequired;
            AdditionalInformation = additionalInformation;
        }
    }
}