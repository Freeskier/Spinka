using System.Collections.Generic;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.EduBlocks.Utils;

namespace Spinka.Application.AssignedTrainingFacilities.Commands
{
    public class ChangeTrainingFacilities : ICommand
    {
        public int EduBlockId { get; set; }
        public string TrainingFacility { get; set; }
        public IEnumerable<TrainingFacilityRequestModel> AssignedTrainingFacilities { get; set; }
    }
}