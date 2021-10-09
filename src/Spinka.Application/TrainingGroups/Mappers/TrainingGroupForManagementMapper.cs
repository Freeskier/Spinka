using System.Linq;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingGroups.Mappers
{
    public class TrainingGroupForManagementMapper : IMapper<TrainingGroup, TrainingGroupForManagementViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingGroupForManagementMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public TrainingGroupForManagementViewModel MapObject(TrainingGroup entity)
        {
            return new TrainingGroupForManagementViewModel
            {
                GroupName = entity.Name,
                GroupId = entity.Id,
                ListOfPersonnelForGroups = entity.TrainingGroupsPersons.Select(x => new PersonForGroupViewModel
                {
                    PersonInGroupId = x.Id,
                    FullName = MapperHelper.HelpWithGetPersonFullName(x.PersonId, _unitOfWork),
                    NoOp = _unitOfWork.Repository<Person>().FindByIdAsync(x.PersonId).GetAwaiter().GetResult().OpNo,
                    OtherGroupStatus = MapperHelper.HelpWithGetOtherTrainingGroupForPerson(x.PersonId, x.TrainingGroupId, _unitOfWork)
                }).ToList()
            };
        }
    }
}