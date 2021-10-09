using System;

namespace Spinka.Application.EduBlocks.Utils
{
    public class TrainingFacilityRequestModel
    {
        public int  TrainingFacilityId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public string Notes { get; set; }
    }
}