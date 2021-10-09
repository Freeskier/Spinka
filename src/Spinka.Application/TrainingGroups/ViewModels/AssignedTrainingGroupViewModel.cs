using System;

namespace Spinka.Application.TrainingGroups.ViewModels
{
    public class AssignedTrainingGroupViewModel
    {
        public int Id { get; set; }
        public int EduBlockId { get; set; }
        public string EduBlock { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}