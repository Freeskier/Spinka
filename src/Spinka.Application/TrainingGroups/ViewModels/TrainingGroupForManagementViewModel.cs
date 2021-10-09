using System.Collections.Generic;

namespace Spinka.Application.TrainingGroups.ViewModels
{
    public class TrainingGroupForManagementViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<PersonForGroupViewModel> ListOfPersonnelForGroups { get; set; }
        
        //
        // public TrainingGroupForManagementViewModel()
        // {
        //     ListOfPersonnelForGroups = new List<PersonForGroupViewModel>();
        // }
    }
}