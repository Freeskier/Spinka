using System.Collections.Generic;

namespace Spinka.Application.MedicalServiceForEduBlocks.ViewModels
{
    public class MedicalServiceForEduBlockViewModel
    {
        public int Id { get; set; }
        public string Driver { get; set; }
        public string Ambulance { get; set; }
        public IEnumerable<AssignedPersonToMedicalServiceViewModel> MedicalStaff { get; set; }
    }
}