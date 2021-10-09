using System.Collections.Generic;

namespace Spinka.Application.GroupForDayReps.ViewModels
{
    public class GetGroupForDayRepViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<PersonnelForGroupViewModel> ListOfPersonnelForGroups { get; set; }

    }
   
}
