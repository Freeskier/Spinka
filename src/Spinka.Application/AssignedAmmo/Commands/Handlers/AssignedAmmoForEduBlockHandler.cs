using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Exceptions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using AssignedAmmoEntity = Spinka.Domain.Models.AssignedAmmo;
using AmmoEntity = Spinka.Domain.Models.Ammo;

namespace Spinka.Application.AssignedAmmo.Commands.Handlers
{
    public class AssignedAmmoForEduBlockHandler : ICommandHandler<AssignedAmmoForEduBlock>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignedAmmoForEduBlockHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(AssignedAmmoForEduBlock command)
        {
            // check limits
            var eduBlockId = command.AssignedAmmo.First().EduBlockId;
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == eduBlockId, includes: i =>
                    i.Include(x => x.AssignedTrainingGroups)
                    .Include(x => x.AssignedAmmo));

            var trainingGroupInDepartment = await _unitOfWork.Repository<TrainingGroupsInDepartment>()
                .FindByAsync(x => x.TrainingGroupId == eduBlock.AssignedTrainingGroups.First().TrainingGroupId);

            var currentLimit = await _unitOfWork.Repository<CurrentAmmoLimitsForDepartment>()
                .FindAllAsync(x => x.UnitDepartmentsId == trainingGroupInDepartment.UnitDepartmentsId);

            foreach (var item in currentLimit)
            {
                foreach (var ammo in command.AssignedAmmo)
                {
                    if (item.AmmoId != ammo.AmmoId) 
                        continue;

                    if (item.Quantity <= ammo.Quantity)
                    {
                        var tmpAmmo = await _unitOfWork.Repository<AmmoEntity>()
                            .FindByIdAsync((int) item.AmmoId);
                        
                        throw new BusinessException(ErrorCodes.NotEnough, $"Limit exceeded for {tmpAmmo.Name}");
                    }

                    item.Quantity -= ammo.Quantity;
                    break;
                }
            }
            
            // if (!eduBlock.AssignedAmmo.Any())
            // {
                var assignedAmmo = command.AssignedAmmo.Select(x => new AssignedAmmoEntity
                    {
                        AmmoId = x.AmmoId, 
                        EduBlockId = x.EduBlockId, 
                        Quantity = x.Quantity
                    })
                    .ToList();

                await _unitOfWork.Repository<AssignedAmmoEntity>().AddRangeAsync(assignedAmmo);
                await _unitOfWork.Commit();
            // }

            // // TODO !!!
            // else
            // {
            //     var newAmmo = new List<AssignedAmmoEntity>();
            //     
            //     foreach (var item in eduBlock.AssignedAmmo)
            //     {
            //         foreach (var ammo in command.AssignedAmmo)
            //         {
            //             if (item.AmmoId == ammo.AmmoId) 
            //                 break;
            //             
            //             newAmmo.Add(ammo);
            //         }
            //     }
            //
            //     if (newAmmo.Any())
            //     {
            //         await _unitOfWork.Repository<AssignedAmmoEntity>().AddRangeAsync(command.AssignedAmmo);
            //         await _unitOfWork.Commit();
            //     }
            // }
        }
    }
}