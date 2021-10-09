using Spinka.Application.DayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using System;
using System.Linq;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;

namespace Spinka.Application.DayReps.Mappers
{
    public class DayRepDataForCalendarMapper : IMapperWithParams<DayRepGroupPerson, DayRepDataForCalendarViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DayRepDataForCalendarMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public DayRepDataForCalendarViewModel MapObject(DayRepGroupPerson entity,  params object[] parameters)
        {
            var login = new SysLogin();
            var startDate = (DateTime) parameters.First();
            var endDate = (DateTime) parameters.Last();
            var groupName = _unitOfWork.Repository<GroupForDayRep>()
                .FindByIdAsync(entity.GroupForDayRepId)
                .GetAwaiter()
                .GetResult()
                .Name;
            
            return new DayRepDataForCalendarViewModel
            {
                GroupId = entity.GroupForDayRepId,
                GroupName = groupName,
                PersonId = entity.PersonId,
                Person = MapperHelper.HelpWithGetPersonFullName(entity.PersonId, _unitOfWork),
                DayReps = entity.DayReps.Where(x => x.Day.Date <= endDate.Date && x.Day.Date >= startDate.Date)
                    .OrderBy(x => x.Day)
                    .Select(x => new DayRepViewModel
                    {
                        Id = x.Id,
                        AccrId = x.DayRepAcronymId,
                        Accr = _unitOfWork.Repository<DayRepAcronym>()
                            .FindByIdAsync((int)x.DayRepAcronymId)
                            .GetAwaiter()
                            .GetResult()
                            .Name,
                        Day = x.Day,
                        Location = x.Location,
                        Description = x.Description,
                        LastUpdate = x.LastUpdate,
                        Login = login.GetLogin()
                    })
            };
        }
    }
}
