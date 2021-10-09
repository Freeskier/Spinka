using Spinka.Application.EventTypes.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.EventTypes.Mappers
{
    public class GetEventTypesMapper : IMapper<EventType, EventTypeViewModel>
    {
        public EventTypeViewModel MapObject(EventType entity)
        {
            return new EventTypeViewModel()
            {
                Id = entity.Id,
                Acr = entity.Acr,
                Color = entity.Color,
                Name = entity.Name
            };
        }
    }
}