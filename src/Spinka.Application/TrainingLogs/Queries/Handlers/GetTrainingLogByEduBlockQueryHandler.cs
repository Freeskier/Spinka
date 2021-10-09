using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Application.TrainingLogs.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Extensions;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingLogs.Queries.Handlers
{
    public class GetTrainingLogByEduBlockQueryHandler : IQueryHandler<GetTrainingLogByEduBlock, IEnumerable<TrainingLogByEduBlockViewModel>>
    {
        private readonly List<int> AbsenceAcronymIDs = new List<int>(){2,4,5,6,7,8,9,10,14,18,21,22,23,24,25,27,28,29,30,31,32};
        private readonly SpinkaContext _ctx;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<EduBlockControl, TrainingLogByEduBlockViewModel> _mapper;

        public GetTrainingLogByEduBlockQueryHandler(SpinkaContext ctx ,IUnitOfWork unitOfWork, IMapper<EduBlockControl, TrainingLogByEduBlockViewModel> mapper)
        {
            _ctx = ctx;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TrainingLogByEduBlockViewModel>> HandleAsync(GetTrainingLogByEduBlock query)
        {
            var eduBlockControls = await _unitOfWork.Repository<EduBlockControl>()
                .FindAllAsync(x => x.EduBlockId == query.EduBlockId && !x.IsDeleted);
            
            var createdControls = await AddNewEduBlockControlsCollection(query.EduBlockId);
            Dictionary<int, EduBlockControl> controlsDict = new Dictionary<int, EduBlockControl>();
            foreach (var blockControl in createdControls)
            {
                controlsDict.Add(blockControl.PersonId, blockControl);
            }

            foreach (var eduBlockControl in eduBlockControls)
            {
                if (eduBlockControl.Attended)
                {
                    controlsDict[eduBlockControl.PersonId] = eduBlockControl;
                }

                controlsDict[eduBlockControl.PersonId].Id = eduBlockControl.Id;
            }
            
            await _unitOfWork.Repository<EduBlockControl>().EditRangeAsync(controlsDict.Values);
            await _unitOfWork.Commit();
            
            return createdControls.Select(_mapper.MapObject);
        }

        private IEnumerable<EduBlockControl> CreateEduBlockControls(IEnumerable<DayRep> dayReps, int eduBlockId)
        {
            List<EduBlockControl> list = new List<EduBlockControl>();
            foreach (var dayRep in dayReps)
            {
                if(dayRep.DayRepAcronym == null) continue;
                
                bool attend = !AbsenceAcronymIDs.Contains(dayRep.DayRepAcronym.Id);

                if (dayRep.DayRepGroupPerson.IsDelegated)
                    attend = false;
                
                var rep = new EduBlockControl()
                {
                    Attended = attend,
                    AbsenceReason = attend ? "" : $"{dayRep.DayRepAcronym.Description} - {dayRep.Description} ({dayRep.Location})",
                    AdminLogin = "Adminlogin",
                    EduBlockId = eduBlockId,
                    LastTimeModified = DateTime.Now,
                    PersonId = dayRep.DayRepGroupPerson.PersonId
                };
                list.Add(rep);
            }

            return list;
        }

        private async Task<IEnumerable<EduBlockControl>> AddNewEduBlockControlsCollection(int eduBlockId)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>().FindByIdAsync(eduBlockId);
            var startTimeEb = eduBlock.StartTime;

            if (eduBlock.EndOn > DateTime.Now)
                throw new Exception("Picked EduBlock must be finished.");
            
            
            var dayReps = await _unitOfWork.Repository<AssignedTrainingGroup>()
                .FindAllWithIncludesAsync(x => x.EduBlockId == eduBlockId,
                    i => i
                .Include(q => q.TrainingGroup.TrainingGroupsPersons)
                            .ThenInclude(q => q.Person)
                            .ThenInclude(q => q.DayRepGroupPersons)
                            .ThenInclude(q => q.DayReps)
                            .ThenInclude(q => q.DayRepAcronym))
                .SelectAsync(e => e.SelectMany(r => r.TrainingGroup.TrainingGroupsPersons)
                    .Select(t => t.Person)
                    .SelectMany(t => t.DayRepGroupPersons)
                    .SelectMany(t => t.DayReps)
                    .Where(d => d.Day.Date == startTimeEb.Date));

            var peopleFromEduBlock = await _unitOfWork.Repository<AssignedTrainingGroup>()
                .FindAllWithIncludesAsync(x => x.EduBlockId == eduBlockId,
                    i => i
                        .Include(q => q.TrainingGroup)
                        .ThenInclude(q => q.TrainingGroupsPersons)
                        .ThenInclude(q => q.Person))
                .SelectAsync(s => s.SelectMany(w => w
                        .TrainingGroup.TrainingGroupsPersons)
                    .Select(r => r.Person));
            
            var uncovered = peopleFromEduBlock.Where(x => !dayReps.Any(y => y.DayRepGroupPerson.PersonId == x.Id));
            var withoutDayRep = CreatePeopleWithoutDayRep(uncovered, eduBlockId);
            
            var final = CreateEduBlockControls(dayReps, eduBlockId).ToList();
            final.AddRange(withoutDayRep);
            
            return final;
        }

        private async Task<List<Person>> AddInctructors(List<Person> people, EduBlock eduBlock)
        {
            List<int> IDs = new List<int>();
            
            IDs.Add(eduBlock.InstructorPersonId);
        
            if (eduBlock.AmmoManagerPersonId.HasValue)
            {
                IDs.Add(eduBlock.AmmoManagerPersonId.Value);
            }

            if (eduBlock.AmmoManagerPersonId.HasValue)
            {
                IDs.Add(eduBlock.AmmoManagerPersonId.Value);
            }

            if(eduBlock.DriverPersonId1.HasValue)
            {
                IDs.Add(eduBlock.DriverPersonId1.Value);
            } 
            
            if(eduBlock.DriverPersonId2.HasValue)
            {
                IDs.Add(eduBlock.DriverPersonId2.Value);
            } 
            
            if(eduBlock.ShootingInstructorPersonId.HasValue)
            {
                IDs.Add(eduBlock.ShootingInstructorPersonId.Value);
            } 
            
            if(eduBlock.ExplosivesManagerPersonId.HasValue)
            {
                IDs.Add( eduBlock.ExplosivesManagerPersonId.Value);
            } 
            
            if(eduBlock.SecurityPersonId.HasValue)
            {
                IDs.Add(eduBlock.SecurityPersonId.Value);
            }

            var additionalPeople = await _unitOfWork.Repository<Person>()
                .FindAllWithIncludesAsync(x => IDs.Contains(x.Id),
                    i => i.Include(q => q.DayRepGroupPersons)
                        .ThenInclude(w => w.DayReps).Include(e => e.PersonInTrainingGroups));

            return additionalPeople.ToList();
        }

        private IEnumerable<EduBlockControl> CreatePeopleWithoutDayRep(IEnumerable<Person> people, int eduBlockId)
        { 
            List<EduBlockControl> eduControls = new List<EduBlockControl>();
            foreach (var person in people)
            {
                eduControls.Add(new EduBlockControl()
                {
                    AbsenceReason = "USER NEEDS TO BE REGISTERED IN DAYREP",
                    AdminLogin = "AdminLogin",
                    Attended = false,
                    EduBlockId = eduBlockId,
                    LastTimeModified = DateTime.Now,
                    PersonId = person.Id
                });
            }

            return eduControls;
        }
    }
}