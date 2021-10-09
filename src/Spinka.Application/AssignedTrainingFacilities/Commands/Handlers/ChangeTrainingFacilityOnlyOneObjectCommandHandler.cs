using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.AssignedTrainingFacilities.Commands.Handlers
{
    public class ChangeTrainingFacilityOnlyOneObjectCommandHandler : ICommandHandler<ChangeTrainingFacilityOnlyOneObject>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeTrainingFacilityOnlyOneObjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(ChangeTrainingFacilityOnlyOneObject command)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .GetOrFailWithIncludesAsync(x => x.Id == command.EduBlockId,
                    includes: i => i.Include(x => x.AssignedTrainingFacilities));

            var trainingFacility = eduBlock.AssignedTrainingFacilities.SingleOrDefault(x =>
                x.TrainingFacilityId == command.LastTrainingFacilityId);

            if (trainingFacility != null)
            {
                trainingFacility.StartTime = command.AssignedTrainingFacility.StartTime;
                trainingFacility.EndOn = command.AssignedTrainingFacility.EndOn;
                trainingFacility.ApprovedByPersonId = -1;
                trainingFacility.Notes = command.AssignedTrainingFacility.Notes;
                trainingFacility.ApprovedTime = DateTime.Now;
                trainingFacility.EduBlockId = eduBlock.Id;
                trainingFacility.TrainingFacilityId = command.AssignedTrainingFacility.TrainingFacilityId;
                
                eduBlock.LastUpdateDateTime = DateTime.Now;
                // eduBlock.LastUpdatePersonId = ;
                
                await _unitOfWork.Repository<AssignedTrainingFacility>().EditAsync(trainingFacility);
                await _unitOfWork.Commit();
            }

            else
            {
                // add throw exception!!!
            }
        }
    }
}