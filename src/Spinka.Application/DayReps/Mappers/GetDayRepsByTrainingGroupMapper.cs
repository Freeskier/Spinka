using Spinka.Application.DayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.DayReps.Mappers
{
    public class GetDayRepsByTrainingGroupMapper : IMapper<DayRep, GetDayRepsByTrainingGroupViewModel>
    {
        public GetDayRepsByTrainingGroupViewModel MapObject(DayRep entity)
        {
            return new GetDayRepsByTrainingGroupViewModel()
            {
                PersonName = entity.DayRepGroupPerson.Person.FirstName,
                DayRepValueName = entity.DayRepAcronym.Description,
                DayRepValueLocation = entity.Location,
                MilitaryRankPl = entity.DayRepGroupPerson.Person.MilitaryRank == null?"": entity.DayRepGroupPerson.Person.MilitaryRank.AcrRankPl,
                PersonOpNo = entity.DayRepGroupPerson.Person.OpNo,
                DayRepValueDescription = entity.Description,
                DayRepValueFull = entity.DayRepAcronym.Description + ", "
                    + entity.Description + ", "
                    + entity.Location
            };
        }
    }
}