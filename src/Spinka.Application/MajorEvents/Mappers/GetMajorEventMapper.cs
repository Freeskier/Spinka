using Spinka.Application.MajorEvents.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.MajorEvents.Mappers
{
    public class GetMajorEventMapper : IMapper<MajorEvent, MajorEventViewModel>
    {
        public MajorEventViewModel MapObject(MajorEvent entity)
        {
            return new MajorEventViewModel()
            {
                Id = entity.Id,
                EventTypeId = entity.EventTypeId,
                AdditionalInformation = entity.AdditionalInformation,
                EndOn = entity.EndOn,
                StartOn = entity.StartOn,
                Name = entity.Name,
                UnitDepartmentId = entity.UnitDepartmentId
            };
        }
    }
}