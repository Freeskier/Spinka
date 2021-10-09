using System.Collections.Generic;
using ICommand = Spinka.Application.Dispatchers.Commands.ICommand;

namespace Spinka.Application.MedicalServiceForEduBlocks.Commands
{
    public class UpdateMedicalService : ICommand
    {
        public int MedicalServiceId { get; set; }
        public int DriverPersonId { get; set; }
        public int AmbulanceVehicleId { get; set; }
        public int EduBlockId { get; set; }
        public IEnumerable<int> MedicalStaffIds { get; set; }
    }
}