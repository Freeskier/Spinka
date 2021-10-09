using Spinka.Application.EduBlocksHistory.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.EduBlocksHistory.Mappers
{
    public class EduBlockHistoryMapper : IMapper<EduBlockHistory, EduBlockHistoryViewModel>
    {
        public EduBlockHistoryViewModel MapObject(EduBlockHistory entity)
        {
            var eduBlockHistory = new EduBlockHistoryViewModel
            {
                StartTime = entity.StartTime,
                EndOn = entity.EndOn,
                ModifyGuid = entity.ModifyGuid,
                InstructorPersonId = entity.InstructorPersonId,
                AmmoManagerPersonId = entity.AmmoManagerPersonId,
                LastUpdateDateTime = entity.LastUpdateDateTime,
                LastUpdatePersonId = entity.LastUpdatePersonId,
                CreatedByPersonId = entity.CreatedByPersonId,
                DriverPersonId1 = entity.DriverPersonId1,
                DriverPersonId2 = entity.DriverPersonId2,
                ShootingInstructorPersonId = entity.ShootingInstructorPersonId,
                ExplosivesManagerPersonId = entity.ExplosivesManagerPersonId,
                SecurityPersonId = entity.SecurityPersonId,
                Approved = entity.Approved,
                ApprovedByPersonId = entity.ApprovedByPersonId,
                ApprovedTime = entity.ApprovedTime,
                TrainingFacility = entity.TrainingFacility,
                CancellingRemarks = entity.CancellingRemarks,
                IsMedicalServiceRequired = entity.IsMedicalServiceRequired,
                AdditionalInformation = entity.AdditionalInformation,
                EduBlockSubjectId = entity.EduBlockSubjectId,
                MedicalServiceForEduBlockId = entity.MedicalServiceForEduBlockId,
                MajorEventId = entity.MajorEventId
            };
            return eduBlockHistory;
        }
    }
}