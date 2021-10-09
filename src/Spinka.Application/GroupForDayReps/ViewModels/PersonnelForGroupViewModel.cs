namespace Spinka.Application.GroupForDayReps.ViewModels
{
    public class PersonnelForGroupViewModel
    {
        public int PersonInGroupId { get; set; }
        public string FullName { get; set; }
        public int? NoOp { get; set; }
        public string OtherGroupsStatus { get; set; }
        public int PersonId { get; set; }
        public bool IsDelegated { get; set; }
    }
}
