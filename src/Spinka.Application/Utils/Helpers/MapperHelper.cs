using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using AssignedAmmoEntity = Spinka.Domain.Models.AssignedAmmo;
using AmmoEntity = Spinka.Domain.Models.Ammo;
using TrainingGroupPerson = Spinka.Domain.Models.TrainingGroupsPerson;

namespace Spinka.Application.Utils.Helpers
{
    public static class MapperHelper
    {
        public static string HelpWithGetTrainingGroupDetailsToEduBlock(int eduBlockId, IUnitOfWork unitOfWork)
        {
            var eduBlock = unitOfWork.Repository<EduBlock>()
                .FindByAsync(x => x.Id == eduBlockId)
                .GetAwaiter()
                .GetResult();

            var eduBlockSubject = unitOfWork.Repository<EduBlockSubject>()
                .FindByAsync(x => x.Id == eduBlock.EduBlockSubjectId)
                .GetAwaiter()
                .GetResult();

            var trainingArea = unitOfWork.Repository<TrainingArea>()
                .FindByAsync(x => x.Id == eduBlockSubject.TrainingAreaId)
                .GetAwaiter()
                .GetResult();

            return $"{trainingArea.Name} {eduBlockSubject.Subject}";
        }
        public static string HelpWithGetPersonFullName(int? personId, IUnitOfWork unitOfWork)
        {
            var person = unitOfWork.Repository<Person>()

                .FindByAsync(x => x.Id == personId)
                .GetAwaiter()
                .GetResult();

            if (person == null || personId == -1)
            {
                return null;
            }
            
            var militaryRank = unitOfWork.Repository<MilitaryRank>()
                .FindByAsync(x => x.Id == person.MilitaryRankId)
                .GetAwaiter()
                .GetResult();

            return militaryRank == null ? $"{person.FirstName} {person.LastName}" : $"{militaryRank.AcrRankPl} {person.FirstName} {person.LastName} /{person.OpNo}/";
        }
        public static int HelpWithGetLimitForAmmo(int ammoId, int eduBlockId, IUnitOfWork unitOfWork)
        {
            var eduBlock = unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == eduBlockId, includes: i =>
                    i.Include(x => x.AssignedTrainingGroups))
                .GetAwaiter()
                .GetResult();

            var trainingGroupInDepartment = unitOfWork.Repository<TrainingGroupsInDepartment>()
                .FindByAsync(x => x.TrainingGroupId == eduBlock.AssignedTrainingGroups.First().TrainingGroupId)
                .GetAwaiter()
                .GetResult();

            var currentLimit = unitOfWork.Repository<CurrentAmmoLimitsForDepartment>()
                .FindByAsync(x => x.UnitDepartmentsId == trainingGroupInDepartment.UnitDepartmentsId
                    && x.AmmoId == ammoId)
                .GetAwaiter()
                .GetResult();

            return currentLimit.Quantity;
        }

        public static string HelpWithGetOtherGroupForPerson(int personId, int groupForDayRepId, IUnitOfWork unitOfWork)
        {
            var groupForPerson = unitOfWork.Repository<DayRepGroupPerson>()
                .FindAllAsync(x => x.PersonId == personId && x.GroupForDayRepId != groupForDayRepId && x.IsDeleted==false)
                .GetAwaiter()
                .GetResult();

            var groupsName = groupForPerson.Select(x => new string(
                unitOfWork.Repository<GroupForDayRep>()
                    .FindByIdAsync(x.GroupForDayRepId)
                    .GetAwaiter()
                    .GetResult()
                    .Name
                )
            );

            var resultList = groupsName.ToList();
            return resultList.Any() ? resultList.Aggregate((a, x) => a + ", " + x) : "Brak innych grup";
        }
        
        public static string HelpWithGetOtherTrainingGroupForPerson(int personId, int trainingGroupId, IUnitOfWork unitOfWork)
        {
            var groupForPerson = unitOfWork.Repository<TrainingGroupPerson>()
                .FindAllAsync(x => x.PersonId == personId && x.TrainingGroupId != trainingGroupId)
                .GetAwaiter()
                .GetResult();

            var groupsName = groupForPerson.Select(x => new string(
                    unitOfWork.Repository<TrainingGroup>()
                        .FindByIdAsync(x.TrainingGroupId)
                        .GetAwaiter()
                        .GetResult()
                        .Name
                )
            );

            var resultList = groupsName.ToList();
            return resultList.Any() ? resultList.Aggregate((a, x) => a + ", " + x) : "Brak innych grup";
        }

        public static PersonEduBlockViewModel HelpWithGetPerson(int? personId, IUnitOfWork unitOfWork)
        {
            if (personId == null)
            {
                return null;
            }
            
            var person = unitOfWork.Repository<Person>()
                .FindByAsync(x => x.Id == personId)
                .GetAwaiter()
                .GetResult();

            if (person == null || personId == -1)
            {
                return null;
            }
            
            return new PersonEduBlockViewModel
                {
                    Id = person.Id,
                    FullName = HelpWithGetPersonFullName(personId, unitOfWork)
                };
        }
        
        public static string HelpWithGetFunctionForEduBlock(int? personId, IUnitOfWork unitOfWork)
        {
            var functionId = unitOfWork.Repository<PersonAuthorisedForEduBlockFunction>()
                .FindByAsync(x => x.Id == personId)
                .GetAwaiter()
                .GetResult()
                .AuthorisationsTypeId;

            var functionName = unitOfWork.Repository<AuthorizationsType>()
                .FindByAsync(x => x.Id == functionId)
                .GetAwaiter()
                .GetResult()
                .Name;

            return functionName;
        }
        
        public static string HelpWithGetOtherDayRepInfo(int groupPersonId, DateTime day, IUnitOfWork unitOfWork)
        {
            var groupForPerson = unitOfWork.Repository<DayRepGroupPerson>()
                .FindByIdAsync(groupPersonId)
                .GetAwaiter()
                .GetResult();
            var personId = groupForPerson.PersonId;


            var groupsForPerson = unitOfWork.Repository<DayRepGroupPerson>()
                 .FindAllWithIncludesAsync(x => x.PersonId == personId, includes: i =>
                 i.Include(x => x.DayReps.Where(p => p.Day == day)).ThenInclude(i => i.DayRepAcronym))
                 .GetAwaiter()
                 .GetResult().ToList();

            var extraInfo = "";

            foreach (var item in groupsForPerson)
            {
                extraInfo = item.GroupForDayRep.Name + ": " + item.DayReps.Select(x => x.DayRepAcronym.Name).First();
            }

            return extraInfo;
        }
        public static string HelpWithOpNo(int? personId, IUnitOfWork unitOfWork)
        {
            var person = unitOfWork.Repository<Person>()
                .FindByAsync(x => x.Id == personId)
                .GetAwaiter()
                .GetResult();


            if (person == null || personId == -1)
            {
                return null;
            }

            string result = "";
            if (person.MilitaryRankId > 0)
            {
                result = person.OpNo.ToString();
            }
           
            if (person.MilitaryRankId == null & person.Pesel != "pies")
            {
                result =  person.FirstName.Substring(0,1) +"."+person.LastName;
            }
            if (person.Pesel == "*pies*")
            {
                result = person.LastName;
            }
            return result;

        }
        public static string HelpWithGetPersonCorpus(int? personId, IUnitOfWork unitOfWork)
        {
            var personaux = unitOfWork.Repository<Person>()
                .FindByAsync(x => x.Id == personId)
                .GetAwaiter()
                .GetResult();
            string rsult = string.Empty;
            if(personaux.MilitaryRank is null)
            {
                if (personaux == null & personaux.Pesel != "pies")
                {
                    rsult = "c";
                }
                if (personaux.Pesel == "*pies*")
                {
                    rsult = "d";
                }
            }
            else
            {
                var person = unitOfWork.Repository<MilitaryRank>()
              .FindByIdAsync((int)personaux.MilitaryRankId)
              .GetAwaiter()
              .GetResult().Grading;

                if (person == null || personId == -1)
                {
                    return null;
                }
                if (person < 3)
                {
                    rsult = "s";
                }
                if (person > 2 && person < 11)
                {
                    rsult = "p";
                }
                if (person > 10)
                {
                    rsult = "o";

                }
            }
          

          


            return rsult;
        }

        public static string HelpWithGetPersonFullNameForOrder(int? personId, IUnitOfWork unitOfWork)
        {
            var person = unitOfWork.Repository<Person>()
                .FindByAsync(x => x.Id == personId)
                .GetAwaiter()
                .GetResult();

            if (person == null || personId == -1)
            {
                return null;
            }

            var militaryRank = unitOfWork.Repository<MilitaryRank>()
                .FindByAsync(x => x.Id == person.MilitaryRankId)
                .GetAwaiter()
                .GetResult();

            return militaryRank == null ? $"{person.FirstName} {person.LastName.ToUpper()}" :
                $"{militaryRank.AcrRankPl} {person.FirstName} {person.LastName.ToUpper()} /{person.OpNo}/ {person.Father}";
        }

        public static string HelpWithGetVehicleDataForOrder(int vehicleId, IUnitOfWork unitOfWork)
        {
            var vehicle = unitOfWork.Repository<Vehicle>()
                .FindByIdAsync(vehicleId)
                .GetAwaiter()
                .GetResult();

            return $"{vehicle.Brand} {vehicle.Model} nr rej. {vehicle.RegisterNumber}";
        }

        public static string HelpWithGetAmmoDataForOrder(AssignedAmmoEntity assignedAmmo, IUnitOfWork unitOfWork)
        {
            var ammo = unitOfWork.Repository<AmmoEntity>()
                .FindByIdAsync(assignedAmmo.AmmoId)
                .GetAwaiter()
                .GetResult();

            var measure = unitOfWork.Repository<MeasureUnit>()
                .FindByIdAsync(ammo.MeasureUnitId)
                .GetAwaiter()
                .GetResult();

            return $"{ammo.Name.ToUpper()} - {assignedAmmo.Quantity} {measure.Acronym}";
        }

        public static string HelpWithGetPlaceForOrder(int trainingFacilityId, IUnitOfWork unitOfWork)
        {
            var trainingFacility = unitOfWork.Repository<TrainingFacility>()
                .FindByIdAsync(trainingFacilityId)
                .GetAwaiter()
                .GetResult();

            return $"{trainingFacility.Name} {trainingFacility.Location}";
        }

        public static EduBlockSubjectForEduBlockViewModel HelpWithGetSubject(int id, IUnitOfWork unitOfWork)
        {
            var subject = unitOfWork.Repository<EduBlockSubject>()
                .FindByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return new EduBlockSubjectForEduBlockViewModel
            {
                Id = id,
                Subject = subject.Subject
            };
        }

        public static TrainingAreaViewModelForEduBlock HelpWithGetTrainingArea(int id, IUnitOfWork unitOfWork)
        {
            var subject = unitOfWork.Repository<EduBlockSubject>()
                .FindByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            var area = unitOfWork.Repository<TrainingArea>()
                .FindByWithIncludesAsync(x => x.Id == subject.TrainingAreaId,
                    includes: i => i.Include(x => x.EduBlockSubjects))
                .GetAwaiter()
                .GetResult();

            return new TrainingAreaViewModelForEduBlock
            {
                Id = area.Id,
                Name = area.Name,
            };
        }

        public static string HelpWithGetPersonFullNameForAmmoReport(int? personId, IUnitOfWork unitOfWork)
        {
            var person = unitOfWork.Repository<Person>()
                .FindByAsync(x => x.Id == personId)
                .GetAwaiter()
                .GetResult();

            if (person == null || personId == -1)
            {
                return null;
            }

            var militaryRank = unitOfWork.Repository<MilitaryRank>()
                .FindByAsync(x => x.Id == person.MilitaryRankId)
                .GetAwaiter()
                .GetResult();

            return militaryRank == null ? $"{person.FirstName} {person.LastName.ToUpper()}" :
                $"{militaryRank.AcrRankPl} {person.FirstName} {person.LastName.ToUpper()} /{person.OpNo}/";
        }

        public static string HelpWithAmmoMeasureForAmmoReport(int? ammoId, IUnitOfWork unitOfWork)
        {
            var ammo = unitOfWork.Repository<AmmoEntity>()
                .FindByAsync(x => x.Id == ammoId)
                .GetAwaiter()
                .GetResult();

            return unitOfWork.Repository<MeasureUnit>()
                .FindByAsync(x => x.Id == ammo.MeasureUnitId)
                .GetAwaiter()
                .GetResult()
                .Acronym;
        }
    }
}
