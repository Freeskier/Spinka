using System;
using System.Collections.Generic;

namespace Spinka.Application.Reports.Trainings.ViewModels
{
    public class TrainingReportViewModel
    {
        public int Id { get; set; }
        public string UnitDepartmentName { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public string TrainingArea { get; set; }
        public string Subject { get; set; }
        public string Place { get; set; }
        public string MainInstructor { get; set; }
        public string Ammo { get; set; }
        public string Remarks { get; set; }
        public List<TrainingGroupForReportViewModel> TrainingGroups { get; set; }
        public List<TrainingGroupForReportViewModel> TmpTrainingGroups = new List<TrainingGroupForReportViewModel>();
    }
}