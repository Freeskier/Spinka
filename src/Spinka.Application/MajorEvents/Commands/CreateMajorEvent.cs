using System;
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.MajorEvents.Commands
{
    public class CreateMajorEvent : ICommand
    {
        public string Name { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime EndOn { get; set; }
        public string AdditionalInformation { get; set; } 
        public int UnitDepartmentId { get; set; }
        public int EventTypeId { get; set; }
    }
}