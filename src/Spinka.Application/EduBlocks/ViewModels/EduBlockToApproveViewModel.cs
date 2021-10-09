using System;

namespace Spinka.Application.EduBlocks.ViewModels
{
    public class EduBlockToApproveViewModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public bool Approved { get; set; }
        public string GroupName { get; set; }
        public string Subject { get; set; }
        public string AssignedFacilityName { get; set; }
    }
}