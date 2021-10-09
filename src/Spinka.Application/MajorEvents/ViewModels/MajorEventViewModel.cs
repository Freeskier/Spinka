using System;

namespace Spinka.Application.MajorEvents.ViewModels
{
    public class MajorEventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime EndOn { get; set; }
        public string AdditionalInformation { get; set; } 
        public int UnitDepartmentId { get; set; }
        public int EventTypeId { get; set; }
    }
}