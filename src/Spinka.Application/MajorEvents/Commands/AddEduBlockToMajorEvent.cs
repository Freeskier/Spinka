
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.MajorEvents.Commands
{
    public class AddEduBlockToMajorEvent : ICommand
    {
        public int MajorEventId { get; set; }
        public int EduBlockId { get; set; }
    }
}