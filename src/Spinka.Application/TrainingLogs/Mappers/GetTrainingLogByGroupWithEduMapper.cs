using System.Linq;
using Spinka.Application.TrainingLogs.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingLogs.Mappers
{
    public class GetTrainingLogByGroupWithEduMapper : IMapper<AssignedTrainingFacility, TrainingLogByGroupWithEduViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTrainingLogByGroupWithEduMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TrainingLogByGroupWithEduViewModel MapObject(AssignedTrainingFacility entity)
        {
            var wasAccount = _unitOfWork.Repository<EduBlockControl>()
                .FindAllAsync(x => x.EduBlockId == entity.EduBlock.Id).Result;
            
            return new TrainingLogByGroupWithEduViewModel()
            {
               StartEduBlockDate = entity.EduBlock.StartTime,
               WasAccounted = wasAccount.Any(),
               EduBlockId = entity.EduBlock.Id,
               Location = entity.TrainingFacility.Location + " : " + entity.TrainingFacility.Name,
               ToDisplay = (entity.EduBlock.EduBlockSubject.TrainingArea.Name ?? "") + "/" + (entity.EduBlock.EduBlockSubject.Subject??"")
            };
        }
    }
}