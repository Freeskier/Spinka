using System.Collections.Generic;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.EduBlocks.Utils;

namespace Spinka.Application.AssignedTrainingFacilities.Commands
{
    public class ChangeTrainingFacilityOnlyOneObject : ICommand
    {
        public int EduBlockId { get; set; }
        public int LastTrainingFacilityId { get; set; }
        public TrainingFacilityRequestModel AssignedTrainingFacility { get; set; }
    }
}