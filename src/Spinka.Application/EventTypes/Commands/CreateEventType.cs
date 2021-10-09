
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.EventTypes.Commands
{
    public class CreateEventType : ICommand
    {
        public string Name { get; set; }
        public string Acr { get; set; }
        public string Color { get; set; }
    }
}