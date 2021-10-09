using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.CurrentAmmoLimitForDepartments.Commands.Handlers
{
    public class AssignedLimitToUnitCommandHandler : ICommandHandler<AssignedLimitToUnit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignedLimitToUnitCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(AssignedLimitToUnit command)
        {
            var unitDepartment = await _unitOfWork.Repository<UnitDepartment>()
                .GetOrFailWithIncludesAsync(x => x.Id == command.UnitDepartmentId,
                    includes: i => i.Include(x => x.CurrentAmmoLimitsForDepartments));

            var currentLimits = command.Ammo.Select(ammo => 
                new CurrentAmmoLimitsForDepartment
                {
                    UnitDepartmentsId = command.UnitDepartmentId, 
                    AmmoId = ammo.AmmoId, 
                    Quantity = ammo.Amount, 
                    ActualizationDate = DateTime.Now
                })
                .ToList();

            await _unitOfWork.Repository<CurrentAmmoLimitsForDepartment>().AddRangeAsync(currentLimits);
            await _unitOfWork.Commit();

            var ammoTransaction = currentLimits.Select(limit => new AmmoTransaction
                {
                    AmmoAdminId = -1,
                    AmmoTransactionTypeId = 5,
                    CurrentAmmoLimitsForDepartmentId = limit.Id,
                    Quantity = limit.Quantity,
                    Remarks = "Stan początkowy",
                    TransactionDateTime = DateTime.Now,
                })
                .ToList();

            await _unitOfWork.Repository<AmmoTransaction>().AddRangeAsync(ammoTransaction);
            await _unitOfWork.Commit();
        }
    }
}