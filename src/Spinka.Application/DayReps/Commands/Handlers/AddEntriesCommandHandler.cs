using System;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using System.Linq;
using Spinka.Application.Utils;

namespace Spinka.Application.DayReps.Commands.Handlers
{
    public class AddEntriesCommandHandler: ICommandHandler<AddEntries>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddEntriesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(AddEntries command)
        {
            var login = new SysLogin();

            foreach (var e in command.DayRepListOfEntries)
            {
                var entry = new DayRep
                {
                    Day = e.Date.Date,
                    DayRepGroupPersonId = e.PersonInGroupForDayRepIdViewModel,
                    DayRepAcronymId = e.AccrId,
                    Description = e.Description,
                    Location = e.Location,
                    LastUpdate = DateTime.Now,
                    Login = login.GetLogin()
                };

                var singleEntry = await _unitOfWork.Repository<DayRep>().FindAllAsync
                    (x => x.Day.Date == e.Date.Date && x.DayRepGroupPersonId == e.PersonInGroupForDayRepIdViewModel);
                if (!singleEntry.Any())
                {
                    await _unitOfWork.Repository<DayRep>().AddAsync(entry);
                    await _unitOfWork.Commit();

                }
                else
                {
                    var entryToBeModified = await _unitOfWork.Repository<DayRep>().FindByAsync
                    (x => x.Day.Date == e.Date.Date && x.DayRepGroupPersonId == e.PersonInGroupForDayRepIdViewModel);
                    entryToBeModified.DayRepAcronymId = e.AccrId;
                    entryToBeModified.Login = login.GetLogin();
                    entryToBeModified.LastUpdate = DateTime.Now;
                    entryToBeModified.Location = e.Location;
                    entryToBeModified.Description = e.Description;

                    await _unitOfWork.Repository<DayRep>().EditAsync(entryToBeModified);
                    await _unitOfWork.Commit();

                }
            }
            
        }
    }
}
