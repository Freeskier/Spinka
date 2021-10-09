using System;
using System.Collections.Generic;

namespace Spinka.Application.Reports.OrderPoints.Models
{
    public class DataModelForOrder
    {
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public string Area { get; set; }
        public string Subject { get; set; }
        public string Place { get; set; }
        public string MainInstructor { get; set; }
        public string Groups { get; set; }
        public List<ModelForName> HelperInstructors { get; set; }
        public string ShootingInstructor { get; set; }
        public string AmmoManger { get; set; }
        public List<ModelForName> MedicalStaff { get; set; }
        public List<ModelForName> Ammo { get; set; }
        public string DriverOne { get; set; }
        public string DriverTwo { get; set; }
        public string Vehicle { get; set; }
        public string TargetPlace { get; set; }

        public DataModelForOrder()
        {
            HelperInstructors = new List<ModelForName>();
            MedicalStaff = new List<ModelForName>();
            Ammo = new List<ModelForName>();
        }
    }
}