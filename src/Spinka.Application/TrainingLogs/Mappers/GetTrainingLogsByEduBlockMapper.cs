using Spinka.Application.TrainingLogs.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingLogs.Mappers
{
    public class GetTrainingLogsByEduBlockMapper : IMapper<EduBlockControl, TrainingLogByEduBlockViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTrainingLogsByEduBlockMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TrainingLogByEduBlockViewModel MapObject(EduBlockControl entity)
        {
            var person = _unitOfWork.Repository<Person>().FindByIdAsync(entity.PersonId).Result;
            return new TrainingLogByEduBlockViewModel
            {
                Attended = entity.Attended,
                AbsenceReason = entity.AbsenceReason,
                FullName = person.FirstName + " " + person.LastName,
                EduBlockControlId = entity.Id
            };
        }
    }
}