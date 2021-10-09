namespace Spinka.Application.DayReps.ViewModels
{
    public class DayRep_RepDBReturnSingle
    {
        public int PersonInGroupID { get; set; }
        public bool IsDelegated { get; set; }
        public string Corpus { get; set; }
        public string OpNumber { get; set; }
        public string fullName { get; set; }
        public int? CurrentDayRepAcrID { get; set; }
        public int? PrevDayRepAcrID { get; set; }
    }
}
