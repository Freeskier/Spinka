using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.MedicalServiceForEduBlocks.Commands.Handlers
{
    public class CreateMedicalServiceCommandHandler : ICommandHandler<CreateMedicalService>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMedicalServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(CreateMedicalService command)
        {
            // check persons -> From day reps!!!
            
            // check if medical service is required to edu block!!!
            
            var medicalService = new MedicalServiceForEduBlock
                {
                    DriverPersonId = command.DriverPersonId,
                    AmbulanceVehicleId = command.AmbulanceVehicleId,
                    MedicalServiceType = command.MedicalServiceType
                };

            await _unitOfWork.Repository<MedicalServiceForEduBlock>().AddAsync(medicalService);
            await _unitOfWork.Commit();
            
            var assignedMedicalServices = command.MedicalStaffIds.Select(x => new AssignedPersonToMedicalService
                {
                    PersonId = x,
                    MedicalServiceForEduBlockId = medicalService.Id
                })
                .ToList();

            await _unitOfWork.Repository<AssignedPersonToMedicalService>().AddRangeAsync(assignedMedicalServices);

            var eduBlock = await _unitOfWork.Repository<EduBlock>().FindByIdAsync(command.EduBlockId);

            eduBlock.MedicalServiceForEduBlockId = medicalService.Id;

            await _unitOfWork.Repository<EduBlock>().EditAsync(eduBlock);
            await _unitOfWork.Commit();
        }
    }
}