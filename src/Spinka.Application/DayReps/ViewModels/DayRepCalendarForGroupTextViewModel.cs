namespace Spinka.Application.DayReps.ViewModels
{
    public class DayRepCalendarForGroupTextViewModel
    {
        public int PersonInGroupId { get; set; }
        public string FullName { get; set; }
        public AuxDay Day1 { get; set; }
        public AuxDay Day2 { get; set; }
        public AuxDay Day3 { get; set; }
        public AuxDay Day4 { get; set; }
        public AuxDay Day5 { get; set; }
        public AuxDay Day6 { get; set; }
        public AuxDay Day7 { get; set; }
        public AuxDay Day8 { get; set; }
        public AuxDay Day9 { get; set; }
        public AuxDay Day10 { get; set; }
        public AuxDay Day11 { get; set; }
        public AuxDay Day12 { get; set; }
        public AuxDay Day13 { get; set; }
        public AuxDay Day14 { get; set; }

        public DayRepCalendarForGroupTextViewModel()
        {
            Day1 = new AuxDay();
            Day2 = new AuxDay();
            Day3 = new AuxDay();
            Day4 = new AuxDay();
            Day5 = new AuxDay();
            Day6 = new AuxDay();
            Day7 = new AuxDay();
            Day8 = new AuxDay();
            Day9 = new AuxDay();
            Day10= new AuxDay();
            Day11= new AuxDay();
            Day12= new AuxDay();
            Day13= new AuxDay();
            Day14 = new AuxDay();
        }

    }
  
}
  public class AuxDay{

    public int? accrId { get; set; }
    public string info { get; set; }
    }