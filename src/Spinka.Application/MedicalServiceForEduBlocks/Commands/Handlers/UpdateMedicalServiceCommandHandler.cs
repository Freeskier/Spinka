using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.MedicalServiceForEduBlocks.Commands.Handlers
{
     public class UpdateMedicalServiceCommandHandler : ICommandHandler<UpdateMedicalService>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMedicalServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(UpdateMedicalService command)
        {
            var medicalService = await _unitOfWork.Repository<MedicalServiceForEduBlock>()
                .GetOrFailWithIncludesAsync(x => x.Id == command.MedicalServiceId,
                    includes: i => i.Include(x => x.MedicalStaff));

            medicalService.DriverPersonId = command.DriverPersonId;
            medicalService.AmbulanceVehicleId = command.AmbulanceVehicleId;
            
            var medicalStaff = new List<AssignedPersonToMedicalService>();

            foreach (var item in command.MedicalStaffIds)
            {
                medicalStaff.Add(await _unitOfWork.Repository<AssignedPersonToMedicalService>()
                    .FindByAsync(x => x.PersonId == item && x.MedicalServiceForEduBlockId == command.MedicalServiceId));
            }

            var medicStaffToDelete = medicalService.MedicalStaff.Where(x => 
                    medicalStaff.All(y => y.Id != x.Id)).ToList();
            
            var medicStaffToAdd = medicalStaff.Where(x => 
                    medicalService.MedicalStaff.All(y => y.Id != x.Id)).ToList();

            if (medicStaffToDelete.Any())
            {
                await _unitOfWork.Repository<AssignedPersonToMedicalService>().DeleteRangeAsync(medicStaffToDelete);
                await _unitOfWork.Commit();
            }
            
            if (medicStaffToAdd.Any())
            {
                await _unitOfWork.Repository<AssignedPersonToMedicalService>().AddRangeAsync(medicStaffToAdd);
                await _unitOfWork.Commit();
            }

            await _unitOfWork.Repository<MedicalServiceForEduBlock>().EditAsync(medicalService);
            await _unitOfWork.Commit();
        }
    }
}