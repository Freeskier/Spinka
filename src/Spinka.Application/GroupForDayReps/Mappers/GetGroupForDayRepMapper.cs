using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using System.Linq;
using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Application.Utils.Helpers;

namespace Spinka.Application.GroupForDayReps.Mappers
{
    public class GetGroupForDayRepMapper : IMapper<GroupForDayRep, GetGroupForDayRepViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGroupForDayRepMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public GetGroupForDayRepViewModel MapObject(GroupForDayRep entity)
        {
            var personsInGroup = _unitOfWork.Repository<DayRepGroupPerson>()
               .FindAllAsync(x => x.GroupForDayRepId == entity.Id && x.IsDeleted==false)
               .GetAwaiter()
               .GetResult();

            return new GetGroupForDayRepViewModel
            {
                GroupName = entity.Name,
                GroupId = entity.Id,
                ListOfPersonnelForGroups = personsInGroup.Select(x => new PersonnelForGroupViewModel
                {
                    PersonInGroupId = x.Id,
                    IsDelegated=x.IsDelegated,
                    FullName = MapperHelper.HelpWithGetPersonFullName(x.PersonId, _unitOfWork),
                    NoOp = _unitOfWork.Repository<Person>().FindByIdAsync(x.PersonId).GetAwaiter().GetResult().OpNo,
                    OtherGroupsStatus = MapperHelper.HelpWithGetOtherGroupForPerson(x.PersonId, x.GroupForDayRepId, _unitOfWork)
                }).ToList()
            };
        }
    }
}
