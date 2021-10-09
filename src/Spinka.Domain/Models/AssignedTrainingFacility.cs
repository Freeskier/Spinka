using System;

namespace Spinka.Domain.Models
{
    public class AssignedTrainingFacility : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public int ApprovedByPersonId { get; set; }
        public string Notes { get; set; }
        public DateTime ApprovedTime { get; set; }  

        public virtual EduBlock EduBlock { get; set; }
        public int EduBlockId { get; set; }

        public virtual TrainingFacility TrainingFacility { get; set; }
        public int  TrainingFacilityId { get; set; }
    }
}