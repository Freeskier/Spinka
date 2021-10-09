using System.Linq;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.EduBlocks.Mappers
{
    public class GetIconsInfoMapper : IMapper<EduBlock, IconsInfoViewModel>
    {
        private readonly string helicopterDB = "ŚMIGŁOWIEC";
        private readonly string shipDB = "ŁÓDŹ";
        public IconsInfoViewModel MapObject(EduBlock entity)
        {
            bool helicopter =
                entity.AssignedTrainingFacilities.Any(x => x.TrainingFacility.Name.StartsWith(helicopterDB));
            
            bool ship =
                entity.AssignedTrainingFacilities.Any(x => x.TrainingFacility.Name.StartsWith(shipDB));

            bool medics = entity.MedicalServiceForEduBlockId == null ? false : true;
            return new IconsInfoViewModel()
            {
                IsCancelled = entity.IsCancelled,
                IsHelicopter = helicopter,
                IsShip = ship,
                IsMedicalServiceGiven = medics,
                IsMajorEvent = entity.MajorEventId != null
            };
        }
    }
}