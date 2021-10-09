using System;
using System.Collections.Generic;
using Spinka.Domain.Models;

namespace Spinka.Application.TrainingLogs.ViewModels
{
    public class TrainingLogByGroupIdViewModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public int InstructorPersonId { get; set; }
        public bool Approved { get; set; }
        public int? ApprovedByPersonId { get; set; }
        public string TrainingFacility { get; set; }
        public bool IsMedicalServiceRequired { get; set; }
        public string AdditionalInformation { get; set; }
        public int EduBlockSubjectId { get; set; }
        public int EduBlockId { get; set; }
        public int? MajorEventId { get; set; }
        public IEnumerable<AssignedTrainingFacility> AssignedTrainingFacilities { get; set; }
        public IEnumerable<EduBlockControl> EduBlockControls { get; set; }
        public string ToDisplay { get; set; }
    }
}