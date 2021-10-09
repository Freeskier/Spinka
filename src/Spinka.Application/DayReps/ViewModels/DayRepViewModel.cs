using System;

namespace Spinka.Application.DayReps.ViewModels
{
    public class DayRepViewModel
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int? AccrId { get; set; }
        public string Accr { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Login { get; set; }
    }
}