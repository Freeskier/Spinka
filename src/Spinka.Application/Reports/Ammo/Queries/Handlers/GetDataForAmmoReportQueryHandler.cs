using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Reports.Ammo.ViewModels;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using AmmoEntity = Spinka.Domain.Models.Ammo;

namespace Spinka.Application.Reports.Ammo.Queries.Handlers
{
    public class GetDataForAmmoReportQueryHandler : IQueryHandler<GetDataForAmmoReport, AmmoReportViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDataForAmmoReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<AmmoReportViewModel> HandleAsync(GetDataForAmmoReport query)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == query.EduBlockId,
                    includes: i => i.Include(x => x.AssignedTrainingGroups)
                        .Include(x => x.AssignedAmmo));

            var unitDepartment = await _unitOfWork.Repository<TrainingGroupsInDepartment>()
                .FindByIdAsync(eduBlock.AssignedTrainingGroups.First().TrainingGroupId);
            
            var unitDepartmentName = await _unitOfWork.Repository<UnitDepartment>()
                .FindByIdAsync(unitDepartment.UnitDepartmentsId);
            
            var subject = await _unitOfWork.Repository<EduBlockSubject>()
                .FindByIdAsync(eduBlock.EduBlockSubjectId);
            
            var data = new AmmoReportViewModel
                {
                    UnitDepartment = unitDepartmentName.Name,
                    MainInstructor = MapperHelper.HelpWithGetPersonFullNameForAmmoReport(eduBlock.InstructorPersonId, _unitOfWork),
                    EduBlockDate = eduBlock.StartTime.Date,
                    AmmoManager = MapperHelper.HelpWithGetPersonFullNameForAmmoReport(eduBlock.AmmoManagerPersonId, _unitOfWork),
                    OrderNumber = query.OrderNumber,
                    OrderDate = query.OrderDate,
                    ShootingInstructor = MapperHelper.HelpWithGetPersonFullNameForAmmoReport(eduBlock.ShootingInstructorPersonId, _unitOfWork),
                    EduBlockSubject = subject.Subject.Substring(subject.Subject.IndexOf(' ') + 1),
                    EduBlockSubjectCode = subject.Subject.Split (' ', 2).First(),
                    DateNow = DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("pl-PL"))
                };

            var id = 0;
            
            data.Ammo.AddRange(eduBlock.AssignedAmmo.Select(x => new AmmoForReportViewModel
                {
                    Idx = ++id,
                    Name = _unitOfWork.Repository<AmmoEntity>()
                        .FindByIdAsync(x.AmmoId)
                        .GetAwaiter()
                        .GetResult()
                        .Name,
                    OperationCode = 261,
                    AmmoIdx = _unitOfWork.Repository<AmmoEntity>()
                        .FindByIdAsync(x.AmmoId)
                        .GetAwaiter()
                        .GetResult()
                        .LogIndex,
                    Measure = MapperHelper.HelpWithAmmoMeasureForAmmoReport(x.AmmoId, _unitOfWork),
                    Quantity = x.Quantity,
                    IdForSecondPage = ConvertIdToOtherId(id)
                }));

            return data;
        }
        
        private static string ConvertIdToOtherId(int id)
        {
            if (id < 10)
            {
                return $"00{id}";
            }

            if (id >= 10 && id < 100)
            {
                return $"0{id}";
            }

            return id.ToString();
        }
    }
}