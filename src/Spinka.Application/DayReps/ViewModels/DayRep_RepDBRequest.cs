using System;

namespace Spinka.Application.DayReps.ViewModels
{
    public class DayRep_RepDBRequest
    {
        public int GroupID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FullNameRenderingPersonId { get; set; }
        public int FullNameSigningPersonId { get; set; }
    }
}
