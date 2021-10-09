using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Application.Reports.Trainings.ViewModels;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Reports.Trainings.Queries.Handlers
{
    public class GetReportDataByMajorEventQueryHandler : IQueryHandler<GetReportDataByMajorEvent, IEnumerable<TrainingReportViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReportDataByMajorEventQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TrainingReportViewModel>> HandleAsync(GetReportDataByMajorEvent query)
        {
            var eduBlocks = await _unitOfWork.Repository<EduBlock>()
                .FindAllWithIncludesAsync(x => x.MajorEventId == query.MajorId && !x.IsDeleted,
                    i => i
                        .Include(q => q.MajorEvent)
                        .Include(q => q.AssignedTrainingGroups)
                        .ThenInclude(q => q.TrainingGroup)
                        .Include(q => q.AssignedTrainingFacilities)
                        );

            var enumerable = eduBlocks.ToList();
            var majEvent = await _unitOfWork.Repository<MajorEvent>().FindByIdAsync(query.MajorId);

            if (!eduBlocks.Any())
                return new List<TrainingReportViewModel>();
            
            var unitDepartment = await _unitOfWork.Repository<UnitDepartment>()
                .FindByWithIncludesAsync(x => x.Id == majEvent.UnitDepartmentId,
                    includes: i => i.Include(x => x.TrainingGroupsInDepartments));

            var tmpEduBlocks = enumerable.SelectMany(x => x.AssignedTrainingGroups
                    .Select(y => y.TrainingGroupId))
                .Except(unitDepartment.TrainingGroupsInDepartments
                    .Select(z => z.TrainingGroupId));
            


            var data = enumerable.Select(x => new TrainingReportViewModel
                {
                    Id = x.Id,
                    UnitDepartmentName = unitDepartment.Name.ToUpperInvariant(),
                    Date = $"{x.StartTime.ToString("dddd", new CultureInfo("pl-PL")).ToUpperCaseFirstInvariant()}, {x.StartTime.Date:dd.MM.yyyy} r.",
                    Month = x.StartTime.ToString("MMMM", new CultureInfo("pl-PL")).ToUpperInvariant(),
                    StartTime = x.StartTime,
                    EndOn = x.EndOn,
                    Subject = _unitOfWork.Repository<EduBlockSubject>()
                        .FindByIdAsync(x.EduBlockSubjectId)
                        .GetAwaiter()
                        .GetResult()
                        .Subject,
                    TrainingArea =  _unitOfWork.Repository<TrainingArea>()
                        .FindByIdAsync((int)_unitOfWork.Repository<EduBlockSubject>()
                            .FindByIdAsync(x.EduBlockSubjectId)
                            .GetAwaiter()
                            .GetResult()
                            .TrainingAreaId)
                        .GetAwaiter()
                        .GetResult()
                        .Name,
                    Place = x.TrainingFacility,
                    MainInstructor = MapperHelper.HelpWithGetPersonFullNameForAmmoReport(x.InstructorPersonId, _unitOfWork),
                    Remarks = x.AdditionalInformation,
                    TrainingGroups = x.AssignedTrainingGroups.Select(y => new TrainingGroupForReportViewModel
                        {
                            Id = y.TrainingGroupId,
                            Name = _unitOfWork.Repository<TrainingGroup>()
                                .FindByIdAsync(y.TrainingGroupId)
                                .GetAwaiter()
                                .GetResult()
                                .Name,
                            IsActive = true
                        })
                        .ToList()
                })
                .OrderBy(x => x.StartTime)
                .ToList();
            
            foreach (var eduBlock in enumerable)
            {
                foreach (var item in data)
                {
                    if (eduBlock.Id == item.Id && item.Place == null)
                    {
                        var place = eduBlock.AssignedTrainingFacilities.Select(x =>
                            MapperHelper.HelpWithGetPlaceForOrder(x.TrainingFacilityId, _unitOfWork));
                            
                        item.Place = place.Aggregate((a, x) => a + ", " + x);
                    }
            
                    if (eduBlock.Id == item.Id && eduBlock.AssignedAmmo.Any())
                    {
                        var ammoTmp = eduBlock.AssignedAmmo.Select(x =>
                            MapperHelper.HelpWithGetAmmoDataForOrder(x, _unitOfWork));
                        item.Ammo = ammoTmp.Aggregate((a, x) => a + ", " + x);
                    }
            
                    if (eduBlock.Id == item.Id && !eduBlock.AssignedAmmo.Any())
                    {
                        item.Ammo = "Brak";
                    }
                }
            }

            foreach (var item in data)
            {
                foreach (var group in item.TrainingGroups)
                {
                    foreach (var groupInDepartment in unitDepartment.TrainingGroupsInDepartments)
                    {
                        if (group.Id != groupInDepartment.TrainingGroupId)
                        {
                            item.TmpTrainingGroups.Add(new TrainingGroupForReportViewModel
                            {
                                Id = groupInDepartment.TrainingGroupId,
                                Name = _unitOfWork.Repository<TrainingGroup>()
                                    .FindByIdAsync(groupInDepartment.TrainingGroupId)
                                    .GetAwaiter()
                                    .GetResult()
                                    .Name,
                                IsActive = false
                            });
                        }
                    }
                }
            }
            
            foreach (var item in data)
            {
                item.TrainingGroups.AddRange(item.TmpTrainingGroups);
                var distinctItems = item.TrainingGroups.GroupBy(x => x.Id)
                    .Select(y => y.First());
                item.TrainingGroups = distinctItems.Select(x => new TrainingGroupForReportViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        IsActive = x.IsActive
                    })
                    .ToList();
            }
            
            return data;
        }
    }
}