using System;

namespace Spinka.Application.EduBlocks.ViewModels
{
    public class EduBlockViewModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
        public bool Approved { get; set; }
        public string ToDisplay { get; set; }
    }
}