using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using TrainingGroupEntity = Spinka.Domain.Models.AssignedTrainingGroup;

namespace Spinka.Application.EduBlocks.Commands.Handlers
{
    public class EditEduBlockCommandHandler : ICommandHandler<EditEduBlock>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditEduBlockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(EditEduBlock command)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .GetOrFailWithIncludesAsync(x => x.Id == command.Id,
                includes: i => i.Include(x => x.AssignedVehicles)
                    .Include(x => x.AssignedTrainingGroups)
                    .Include(x => x.AssignedAmmo)
                    .Include(x => x.AssignedTrainingFacilities)
                    .Include(x => x.AuxPersons)
                    .Include(x => x.AssistantInstructors));

            await _unitOfWork.Repository<EduBlock>().DeleteAsync(eduBlock);
            await _unitOfWork.Commit();
            
            #region TODO

            // available persons -> from day reps!!!
            
            
            // available cars
            
            
            #endregion
            
            var newEduBlock = new EduBlock
            {
                StartTime = command.StartTime,
                EndOn = command.EndOn,
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
                CreatedByPersonId = -1,
                TrainingFacility = command.TrainingFacility,
                IsMedicalServiceRequired = command.IsMedicalServiceRequired,
                AdditionalInformation = command.AdditionalInformation
            };
            var eduBlockHistory = new EduBlockHistory
            {
                StartTime = eduBlock.StartTime,
                EndOn = eduBlock.EndOn,
                EduBlockSubjectId = eduBlock.EduBlockSubjectId,
                InstructorPersonId = eduBlock.InstructorPersonId,
                ShootingInstructorPersonId = eduBlock.ShootingInstructorPersonId,
                AmmoManagerPersonId = eduBlock.AmmoManagerPersonId,
                DriverPersonId1 = eduBlock.DriverPersonId1,
                DriverPersonId2 = eduBlock.DriverPersonId2,
                ExplosivesManagerPersonId = eduBlock.ExplosivesManagerPersonId,
                SecurityPersonId = eduBlock.SecurityPersonId,
                LastUpdateDateTime = DateTime.Now,
                LastUpdatePersonId = eduBlock.LastUpdatePersonId,
                CreatedByPersonId = -1,
                TrainingFacility = eduBlock.TrainingFacility,
                IsMedicalServiceRequired = eduBlock.IsMedicalServiceRequired,
                AdditionalInformation = eduBlock.AdditionalInformation,
                MajorEventId = eduBlock.MajorEventId,
                ApprovedByPersonId = eduBlock.ApprovedByPersonId,
                
                
            };
            newEduBlock.ModifyGuid = eduBlock.ModifyGuid;
            eduBlockHistory.ModifyGuid = eduBlock.ModifyGuid;
            
            await _unitOfWork.Repository<EduBlock>().AddAsync(newEduBlock);
            await _unitOfWork.Repository<EduBlockHistory>().AddAsync(eduBlockHistory);
            await _unitOfWork.Commit();

            command.EduBlockId = newEduBlock.Id;

            var auxPersons = command.AuxPersons.Select(x => new AuxPersonForEduBlock
                {
                    PersonId = x.Id,
                    EduBlockId = newEduBlock.Id
                })
                .ToList();

            var assistantInstructors = command.AssistantInstructors.Select(x => new AssignedAssistantInstructor
                {
                    PersonId = x.Id,
                    EduBlockId = newEduBlock.Id
                })
                .ToList();

            var trainingGroups = command.AssignedTrainingGroups.Select(x => new TrainingGroupEntity
                {
                    TrainingGroupId = x.Id,
                    EduBlockId = newEduBlock.Id
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
                        EduBlockId = newEduBlock.Id,
                        TrainingFacilityId = x.TrainingFacilityId
                    })
                    .ToList();
                
                await _unitOfWork.Repository<AssignedTrainingFacility>().AddRangeAsync(trainingFacilities);
            }
            
            var vehicles = command.AssignedVehicles.Select(x => new AssignedVehicle
                {
                    EduBlockId = newEduBlock.Id,
                    VehicleId = x.Id
                })
                .ToList();

            await _unitOfWork.Repository<AuxPersonForEduBlock>().AddRangeAsync(auxPersons);
            await _unitOfWork.Repository<AssignedAssistantInstructor>().AddRangeAsync(assistantInstructors);
            await _unitOfWork.Repository<TrainingGroupEntity>().AddRangeAsync(trainingGroups);
            await _unitOfWork.Repository<AssignedVehicle>().AddRangeAsync(vehicles);
            await _unitOfWork.Commit();

            // eduBlock.StartTime = command.StartTime;
            // eduBlock.EndOn = command.EndOn;
            // eduBlock.EduBlockSubjectId = command.EduBlockSubjectId;
            // eduBlock.InstructorPersonId = command.InstructorPersonId;
            // eduBlock.ShootingInstructorPersonId = command.ShootingInstructorPersonId;
            // eduBlock.AmmoManagerPersonId = command.AmmoManagerPersonId;
            // eduBlock.DriverPersonId1 = command.DriverPersonId1;
            // eduBlock.DriverPersonId2 = command.DriverPersonId2;
            // eduBlock.SecurityPersonId = command.SecurityPersonId;
            // eduBlock.ExplosivesManagerPersonId = command.ExplosivesManagerPersonId;
            // eduBlock.LastUpdateDateTime = DateTime.Now;
            // eduBlock.LastUpdatePersonId = command.LastUpdatePersonId;
            // eduBlock.TrainingFacility = command.TrainingFacility;
            // eduBlock.IsMedicalServiceRequired = command.IsMedicalServiceRequired;
            //
            // var differentAuxPersons = eduBlock.AuxPersons
            //     .Select(x => x.PersonId)
            //     .Except(command.AuxPersons.
            //         Select(x => x.Id))
            //     .Concat(command.AuxPersons
            //         .Select(x => x.Id)
            //         .Except(eduBlock.AuxPersons
            //             .Select(x => x.PersonId)))
            //     .ToList();
            //
            // if (differentAuxPersons.Count > 0)
            // {
            //     // remove object in db and add different between two lists!!!
            // }
            //
            // var differentTrainingGroups = eduBlock.AssignedTrainingGroups
            //     .Select(x => x.TrainingGroupId)
            //     .Except(command.AssignedTrainingGroups
            //         .Select(x => x.Id))
            //     .Concat(command.AssignedTrainingGroups
            //         .Select(x => x.Id)
            //         .Except(eduBlock.AssignedTrainingGroups
            //             .Select(x => x.TrainingGroupId)))
            //     .ToList();
            //
            // if (differentTrainingGroups.Count > 0)
            // {
            //     // remove object in db and add different between two lists!!!
            // }
            //
            // var differentVehicles = eduBlock.AssignedVehicles
            //     .Select(x => x.VehicleId)
            //     .Except(command.AssignedVehicles
            //         .Select(x => x.Id))
            //     .Concat(command.AssignedVehicles
            //         .Select(x => x.Id)
            //         .Except(eduBlock.AssignedVehicles
            //             .Select(x => x.VehicleId)))
            //     .ToList();
            //
            // if (differentVehicles.Count > 0)
            // {
            //     // remove object in db and add different between two lists!!!
            // }
            //
            // await _unitOfWork.Repository<EduBlock>().EditAsync(eduBlock);
            // await _unitOfWork.Commit();
        }
    }
}