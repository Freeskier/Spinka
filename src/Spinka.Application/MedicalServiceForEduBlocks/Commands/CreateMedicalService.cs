using System.Collections.Generic;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models.Enums;

namespace Spinka.Application.MedicalServiceForEduBlocks.Commands
{
    public class CreateMedicalService : ICommand
    {
        public int DriverPersonId { get; set; }
        public int AmbulanceVehicleId { get; set; }
        public int EduBlockId { get; set; }

        public MedicalServiceType MedicalServiceType { get; set; }
        public IEnumerable<int> MedicalStaffIds { get; set; }
    }
}