using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class EventType : BaseEntity
    {
        public string Name { get; set; }
        public string Acr { get; set; }
        public string Color { get; set; }
        
        private ISet<MajorEvent> _majorEvents = new HashSet<MajorEvent>();
        public IEnumerable<MajorEvent> MajorEvents => _majorEvents;
    }
}