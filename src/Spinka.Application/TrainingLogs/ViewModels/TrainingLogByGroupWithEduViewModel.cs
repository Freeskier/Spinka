using System;

namespace Spinka.Application.TrainingLogs.ViewModels
{
    public class TrainingLogByGroupWithEduViewModel
    {
        public string ToDisplay { get; set; }
        public string Location { get; set; }
        public DateTime StartEduBlockDate { get; set; }
        public int EduBlockId { get; set; }
        public bool WasAccounted { get; set; }
    }
}