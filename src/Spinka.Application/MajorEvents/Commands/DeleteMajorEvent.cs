using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.MajorEvents.Commands
{
    public class DeleteMajorEvent : ICommand
    {
        public int MajorEventId { get; set; }
    }
}