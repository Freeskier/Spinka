using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.CurrentAmmoLimitForDepartments.Commands.Handlers
{
    public class UpdateLimitCommandHandler : ICommandHandler<UpdateLimit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLimitCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(UpdateLimit command)
        {
            var unitDepartment = await _unitOfWork.Repository<UnitDepartment>()
                .GetOrFailWithIncludesAsync(x => x.Id == command.UnitDepartmentId,
                    includes: i => i.Include(x => x.CurrentAmmoLimitsForDepartments));
            
            if (command.ShiftUnitDepartmentId == null || command.ShiftUnitDepartmentId == 0)
            {
                foreach (var changeAmmoLimit in command.Ammo)
                {
                    foreach (var currentAmmoLimit in unitDepartment.CurrentAmmoLimitsForDepartments)
                    {
                        if (changeAmmoLimit.AmmoId != currentAmmoLimit.AmmoId) 
                            continue;
                        
                        await ChangeLimit(changeAmmoLimit, currentAmmoLimit, _unitOfWork);
                        break;
                    }
                }
                
                await _unitOfWork.Repository<UnitDepartment>().EditAsync(unitDepartment);
                await _unitOfWork.Commit();
            }

            else
            {
                var unitDepartmentToShift = await _unitOfWork.Repository<UnitDepartment>()
                    .FindByWithIncludesAsync(x => x.Id == command.ShiftUnitDepartmentId,
                        includes: i => i.Include(x => x.CurrentAmmoLimitsForDepartments));
                
                foreach (var changeAmmoLimit in command.Ammo)
                {
                    foreach (var currentAmmoLimit in unitDepartment.CurrentAmmoLimitsForDepartments)
                    {
                        foreach (var currentAmmoLimitToShift in unitDepartmentToShift.CurrentAmmoLimitsForDepartments)
                        {
                            if (changeAmmoLimit.AmmoId == currentAmmoLimit.AmmoId && currentAmmoLimit.AmmoId == currentAmmoLimitToShift.AmmoId)
                            {
                                await ChangeLimit(changeAmmoLimit, currentAmmoLimit, _unitOfWork, currentAmmoLimitToShift);
                                break;
                            }

                            if (changeAmmoLimit.AmmoId != currentAmmoLimit.AmmoId) 
                                continue;
                            
                            await ChangeLimit(changeAmmoLimit, currentAmmoLimit, _unitOfWork, currentAmmoLimitToShift);
                            break;
                        }
                    }
                }
                
                await _unitOfWork.Repository<UnitDepartment>().EditAsync(unitDepartment);
                await _unitOfWork.Repository<UnitDepartment>().EditAsync(unitDepartmentToShift);
                await _unitOfWork.Commit();
            }
        }

        private static async Task ChangeLimit(ChangeAmmoLimitViewModel changeLimit, 
            CurrentAmmoLimitsForDepartment currentLimit, IUnitOfWork unitOfWork,
            CurrentAmmoLimitsForDepartment currentLimitToShift = null)
        {
            switch (changeLimit.AmmoTransactionTypeId)
            {
                case 1: // zmniejszenie
                    
                    await ReductionLimit(changeLimit, currentLimit, unitOfWork);
                    break;
                
                case 2: // zwiekszenie
                    
                    await IncreaseLimit(changeLimit, currentLimit, unitOfWork);
                    break;
                
                case 3: // Zajecia
                    
                    await ReductionLimit(changeLimit, currentLimit, unitOfWork);
                    break;
                
                case 4: // Zwrot z zajec

                    await IncreaseLimit(changeLimit, currentLimit, unitOfWork);
                    break;
                
                case 5: // Wybrakowanie

                    await ReductionLimit(changeLimit, currentLimit, unitOfWork);
                    break;
                
                case 6: // przesunięcie
                    
                    await ReductionLimit(changeLimit, currentLimit, unitOfWork);
                    await IncreaseLimit(changeLimit, currentLimitToShift, unitOfWork);
                    break;
            }
        }

        private static async Task IncreaseLimit(ChangeAmmoLimitViewModel changeLimit, 
            CurrentAmmoLimitsForDepartment currentLimit, IUnitOfWork unitOfWork)
        {
            var ammoTransactionTwo = new AmmoTransaction
                {
                    Quantity = changeLimit.Amount,
                    AmmoAdminId = -1, // NA SZTYWNO NARAZIE,
                    TransactionDateTime = DateTime.Now,
                    Remarks = changeLimit.Remarks,
                    AmmoTransactionTypeId = changeLimit.AmmoTransactionTypeId,
                    CurrentAmmoLimitsForDepartmentId = currentLimit.Id
                };

            currentLimit.Quantity += changeLimit.Amount;
                    
            await unitOfWork.Repository<AmmoTransaction>().AddAsync(ammoTransactionTwo);
            await unitOfWork.Commit();
        }

        private static async Task ReductionLimit(ChangeAmmoLimitViewModel changeLimit, 
            CurrentAmmoLimitsForDepartment currentLimit, IUnitOfWork unitOfWork)
        {
            var ammoTransactionOne = new AmmoTransaction
                {
                    Quantity = changeLimit.Amount,
                    AmmoAdminId = -1, // NA SZTYWNO NARAZIE,
                    TransactionDateTime = DateTime.Now,
                    Remarks = changeLimit.Remarks,
                    AmmoTransactionTypeId = changeLimit.AmmoTransactionTypeId,
                    CurrentAmmoLimitsForDepartmentId = currentLimit.Id
                };

            currentLimit.Quantity -= changeLimit.Amount;
                    
            await unitOfWork.Repository<AmmoTransaction>().AddAsync(ammoTransactionOne);
            await unitOfWork.Commit();
        }
    }
}