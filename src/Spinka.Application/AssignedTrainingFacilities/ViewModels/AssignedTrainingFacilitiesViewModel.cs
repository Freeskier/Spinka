using System;

namespace Spinka.Application.AssignedTrainingFacilities.ViewModels
{
    public class AssignedTrainingFacilitiesViewModel
    {
        public int Id { get; set; }
        public int TrainingFacilityId { get; set; }
        public int EduBlockId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public string MainGroup { get; set; }
        public string TrainingArea { get; set; }
        public string MainInstructor { get; set; }
    }
}