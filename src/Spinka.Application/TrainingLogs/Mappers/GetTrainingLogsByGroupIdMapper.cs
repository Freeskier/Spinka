using System;
using System.Collections.Generic;
using System.Linq;
using Spinka.Application.TrainingLogs.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingLogs.Mappers
{
    public class GetTrainingLogsByGroupIdMapper : IMapper<EduBlock, TrainingLogByGroupIdViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTrainingLogsByGroupIdMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public TrainingLogByGroupIdViewModel MapObject(EduBlock entity)
        {
            var groupName = _unitOfWork.Repository<TrainingGroup>()
                .FindByAsync(x => x.Id == entity.AssignedTrainingGroups.First().TrainingGroupId)
                .GetAwaiter()
                .GetResult().Name;
            
            var eduBlockSubject = _unitOfWork.Repository<EduBlockSubject>()
                .FindByAsync(x => x.Id == entity.EduBlockSubjectId)
                .GetAwaiter()
                .GetResult();
            
            return new TrainingLogByGroupIdViewModel()
            {
                StartTime = entity.StartTime,
                EndOn = entity.EndOn,
                InstructorPersonId = entity.InstructorPersonId,
                Approved = entity.Approved,
                ApprovedByPersonId = entity.ApprovedByPersonId ?? 0,
                TrainingFacility = entity.TrainingFacility,
                IsMedicalServiceRequired = entity.IsMedicalServiceRequired,
                AdditionalInformation = entity.AdditionalInformation,
                EduBlockSubjectId = entity.EduBlockSubjectId,
                MajorEventId = entity.MajorEventId,
                AssignedTrainingFacilities = entity.AssignedTrainingFacilities,
                EduBlockControls = entity.EduBlockControls, 
                ToDisplay = $"{groupName} {eduBlockSubject.Subject}",
                EduBlockId = entity.Id
            };
        }
    }
}