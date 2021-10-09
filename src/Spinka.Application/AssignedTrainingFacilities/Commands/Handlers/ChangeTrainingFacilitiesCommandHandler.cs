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
    public class ChangeTrainingFacilitiesCommandHandler : ICommandHandler<ChangeTrainingFacilities>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeTrainingFacilitiesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task HandleAsync(ChangeTrainingFacilities command)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .GetOrFailWithIncludesAsync(x => x.Id == command.EduBlockId,
                    includes: i => i.Include(x => x.AssignedTrainingFacilities));

            if (command.TrainingFacility == null)
            {
                var trainingFacilities = command.AssignedTrainingFacilities.Select(x => new AssignedTrainingFacility
                    {
                        StartTime = x.StartTime,
                        EndOn = x.EndOn,
                        ApprovedByPersonId = -1,
                        Notes = x.Notes,
                        ApprovedTime = DateTime.Now,
                        EduBlockId = eduBlock.Id,
                        TrainingFacilityId = x.TrainingFacilityId
                    })
                    .ToList();
                
                await _unitOfWork.Repository<AssignedTrainingFacility>().AddRangeAsync(trainingFacilities);
            }
            
            else
            {
                eduBlock.TrainingFacility = command.TrainingFacility;    
            }
            
            eduBlock.LastUpdateDateTime = DateTime.Now;
            // eduBlock.LastUpdatePersonId = ;

            await _unitOfWork.Commit();
        }
    }
}