using System;

namespace Spinka.Application.EduBlocks.ViewModels
{
    public class AssignedTrainingFacilityToEduBlockViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ToDisplay => $"{Name} {Location}";
    }
}