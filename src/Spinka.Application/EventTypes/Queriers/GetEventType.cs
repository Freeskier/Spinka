using System.Collections;
using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EventTypes.ViewModels;

namespace Spinka.Application.EventTypes.Queriers
{
    public class GetEventType : IQuery<EventTypeViewModel>
    {
        public int Id { get; set; }

        public GetEventType(int id)
        {
            Id = id;
        }
    }
}