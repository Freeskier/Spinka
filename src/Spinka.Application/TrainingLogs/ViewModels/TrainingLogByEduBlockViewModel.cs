using System;

namespace Spinka.Application.TrainingLogs.ViewModels
{
    public class TrainingLogByEduBlockViewModel
    {
        public int EduBlockControlId { get; set; }
        public string FullName { get; set; }
        public bool Attended { get; set; }
        public string AbsenceReason { get; set; }

    }
}