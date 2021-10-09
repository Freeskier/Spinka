using System;
using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using TrainingGroupEntity = Spinka.Domain.Models.AssignedTrainingGroup;

namespace Spinka.Application.EduBlocks.Commands.Handlers
{
    public class CreateEduBlockCommandHandler : ICommandHandler<CreateEduBlock>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEduBlockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(CreateEduBlock command)
        {
            // check data -> Refactor user can plain many edu blocks same time!!! [check only approved]
            
            // var eduBlocksForDate = await _unitOfWork.Repository<EduBlock>()
            //     .FindAllAsync(x => !(x.StartTime > command.EndOn || x.EndOn < command.StartTime) && x.Approved);
            //
            // if (eduBlocksForDate.Any())
            // {
            //     throw new BusinessException(ErrorCodes.Exist, "You should change date for edu block");
            // }
            //
            // // check time training facilities -> THINK ABOUT THIS MAY REFACTOR!!! -> only approved 
            //
            // if (command.TrainingFacility == null)
            // {
            //     var assignedTrainingFacilitiesForTime = await _unitOfWork.Repository<AssignedTrainingFacility>()
            //         .FindAllAsync(x => x.StartTime.Date == command.StartTime.Date
            //                            && x.EndOn.Date == command.EndOn.Date);
            //
            //     foreach (var item in command.AssignedTrainingFacilities)
            //     {
            //         foreach (var trainingFacility in (List<AssignedTrainingFacility>) assignedTrainingFacilitiesForTime)
            //         {
            //             if (!IsTrainingFacilityAvailable(item, trainingFacility))
            //             {
            //                 throw new BusinessException(ErrorCodes.Exist,
            //                     "You should change date for training facility");
            //             }
            //         }
            //     }
            // }

            #region TODO

            // available persons -> from day rep!!!

            #endregion
            
            var eduBlock = new EduBlock
            {
                StartTime = command.StartTime,
                EndOn = command.EndOn,
                ModifyGuid = Guid.NewGuid(),
                EduBlockSubjectId = command.EduBlockSubjectId,
                InstructorPersonId = command.InstructorPersonId,
                ShootingInstructorPersonId = command.ShootingInstructorPersonId,
                AmmoManagerPersonId = command.AmmoManagerPersonId,
                DriverPersonId1 = command.DriverPersonId1,
                DriverPersonId2 = command.DriverPersonId2,
                ExplosivesManagerPersonId = command.ExplosivesManagerPersonId,
                SecurityPersonId = command.SecurityPersonId,
                LastUpdateDateTime = DateTime.Now,
                LastUpdatePersonId = command.LastUpdatePersonId,
                CreatedByPersonId = command.CreatedByPersonId,
                TrainingFacility = command.TrainingFacility,
                IsMedicalServiceRequired = command.IsMedicalServiceRequired,
                AdditionalInformation = command.AdditionalInformation
            };

            await _unitOfWork.Repository<EduBlock>().AddAsync(eduBlock);
            await _unitOfWork.Commit();

            command.EduBlockId = eduBlock.Id;
            
            var auxPersons = command.AuxPersons.Select(x => new AuxPersonForEduBlock
                {
                    PersonId = x.Id,
                    EduBlockId = eduBlock.Id
                })
                .ToList();

            var assistantInstructors = command.AssistantInstructors.Select(x => new AssignedAssistantInstructor
                {
                    PersonId = x.Id,
                    EduBlockId = eduBlock.Id
                })
                .ToList();

            var trainingGroups = command.AssignedTrainingGroups.Select(x => new TrainingGroupEntity
                {
                    TrainingGroupId = x.Id,
                    EduBlockId = eduBlock.Id
                })
                .ToList();

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

            var vehicles = command.AssignedVehicles.Select(x => new AssignedVehicle
                {
                    EduBlockId = eduBlock.Id,
                    VehicleId = x.Id
                })
                .ToList();

            await _unitOfWork.Repository<AuxPersonForEduBlock>().AddRangeAsync(auxPersons);
            await _unitOfWork.Repository<AssignedAssistantInstructor>().AddRangeAsync(assistantInstructors);
            await _unitOfWork.Repository<TrainingGroupEntity>().AddRangeAsync(trainingGroups);
            await _unitOfWork.Repository<AssignedVehicle>().AddRangeAsync(vehicles);
            await _unitOfWork.Commit();
        }
        
        // private static bool IsTrainingFacilityAvailable(TrainingFacilityRequestModel first, AssignedTrainingFacility second)
        // {
        //     if (first.StartTime.TimeOfDay < DateTime.Now.TimeOfDay)
        //     {
        //         return false;
        //     }
        //
        //     if (first.StartTime.TimeOfDay > second.StartTime.TimeOfDay && 
        //         first.StartTime.TimeOfDay > first.EndOn.TimeOfDay && 
        //         first.EndOn.TimeOfDay > second.StartTime.TimeOfDay)
        //     {
        //         return false;
        //     }
        //
        //     return first.StartTime.TimeOfDay >= second.EndOn.TimeOfDay || 
        //            first.EndOn.TimeOfDay >= second.EndOn.TimeOfDay || 
        //            first.StartTime.TimeOfDay <= first.EndOn.TimeOfDay;
        // }
    }
}