using System;
using System.Collections.Generic;

namespace Spinka.Application.Reports.Ammo.ViewModels
{
    public class AmmoReportViewModel
    {
        public string UnitDepartment { get; set; }
        public string MainInstructor { get; set; }
        public string ShootingInstructor { get; set; }
        public DateTime EduBlockDate { get; set; }
        public string Day => EduBlockDate.ToString("dd");
        public string Month => EduBlockDate.ToString("MM");
        public string Year => EduBlockDate.ToString("yy");
        public string EduBlockSubject { get; set; }
        public string EduBlockSubjectCode { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string AmmoManager { get; set; }
        public string DateNow { get; set; }
        public List<AmmoForReportViewModel> Ammo { get; set; }
        
        public AmmoReportViewModel()
        {
            Ammo = new List<AmmoForReportViewModel>();
        }
    }
}