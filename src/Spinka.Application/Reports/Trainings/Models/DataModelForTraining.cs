using System;

namespace Spinka.Application.Reports.Trainings.Models
{
    public class DataModelForTraining
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public string TrainingArea { get; set; }
        public string Subject { get; set; }
        public string Place { get; set; }
        public string MainInstructor { get; set; }
        public string Ammo { get; set; }
        public string Remarks { get; set; }
        
    }
}