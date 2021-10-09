using Spinka.Application.DayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.DayReps.Mappers
{
    public class DayRepAcronymMapper : IMapper<DayRepAcronym, DayRepAcronymViewModel>
    {
        public DayRepAcronymViewModel MapObject(DayRepAcronym entity)
        {
            return new DayRepAcronymViewModel
            {
                Id = entity.Id,
                Accronym = entity.Name,
                Description = entity.Description,
                Color = entity.Color
            };
        }
    }
}
