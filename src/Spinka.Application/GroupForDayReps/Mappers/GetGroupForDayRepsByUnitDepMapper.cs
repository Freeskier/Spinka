using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.GroupForDayReps.Mappers
{
    public class GetGroupForDayRepsByUnitDepMapper :IMapper<GroupForDayRep, GetGroupForDayRepByUnitDepViewModel>
    {
        public GetGroupForDayRepByUnitDepViewModel MapObject(GroupForDayRep entity)
        {
            return new GetGroupForDayRepByUnitDepViewModel()
            {
                Id = entity.Id,
                DayRepName = entity.Name
            };
        }
    }
}