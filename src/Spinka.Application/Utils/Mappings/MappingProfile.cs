using System.Linq;
using AutoMapper;
using Spinka.Application.Ammo.ViewModels;
using Spinka.Application.AmmoTransactionTypes.ViewModels;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Application.EduBlockSubjects.ViewModels;
using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Application.Persons.ViewModels;
using Spinka.Application.TrainingAreas.ViewModels;
using Spinka.Application.TrainingFacilities.ViewModels;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Application.UnitDepartments.ViewModels;
using Spinka.Application.Vehicles.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using TrainingGroupPerson = Spinka.Domain.Models.TrainingGroupsPerson;
using AmmoEntity = Spinka.Domain.Models.Ammo;

namespace Spinka.Application.Utils.Mappings
{
    public class MappingProfile : Profile
    {
        private readonly IUnitOfWork _unitOfWork;

        public MappingProfile(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public MappingProfile()
        {
            CreateMap<UnitDepartment, UnitDepartmentViewModel>();
            CreateMap<TrainingGroup, TrainingGroupViewModel>();
            CreateMap<TrainingArea, TrainingAreaViewModel>();
            CreateMap<EduBlockSubject, EduBlockSubjectForTrainingAreaViewModel>();
            CreateMap<EduBlockSubject, EduBlockSubjectViewModel>();
            CreateMap<AmmoTransactionType, AmmoTransactionTypeViewModel>();
            CreateMap<EduBlock, MajorEventAssignedToEduBlockViewModel>()
                .ForMember(vm => vm.Name, opt =>
                    opt.MapFrom(dm => dm.MajorEvent.Name))
                .ForMember(vm => vm.Id, opt =>
                    opt.MapFrom(dm => dm.MajorEventId));
            
            CreateMap<AmmoEntity, AmmoViewModel>()
                .ForMember(vm => vm.MeasureUnit, 
                    opt => 
                        opt.MapFrom(dm => dm.MeasureUnit.Acronym))
                .ForMember(vm => vm.AmmoType, 
                    opt => 
                        opt.MapFrom(dm => dm.AmmoType.Name));
            
            CreateMap<CurrentAmmoLimitsForDepartment, LimitForDepartmentViewModel>()
                .ForMember(vm => vm.Ammo, 
                    opt => 
                        opt.MapFrom(dm => dm.Ammo.Name))
                .ForMember(vm => vm.Measure, 
                    opt => 
                        opt.MapFrom(dm => dm.Ammo.MeasureUnit.Acronym));
            
            CreateMap<CurrentAmmoLimitsForDepartment, LimitForAmmoViewModel>()
                .ForMember(vm => vm.Measure, 
                opt => 
                    opt.MapFrom(dm => dm.Ammo.MeasureUnit.Acronym))
                .ForMember(vm => vm.UnitDepartment, 
                    opt => 
                        opt.MapFrom(dm => dm.UnitDepartment.Name));
            
            CreateMap<Person, PersonsForDropdownViewModel>()
                .ForMember(vm => vm.PersonId, 
                    opt => 
                        opt.MapFrom(dm => dm.Id))
                .ForMember(vm => vm.PersonFullData,
                    opt => 
                        opt.MapFrom(dm => dm.MilitaryRankId == null ? $"{dm.FirstName} {dm.LastName}" : 
                            $"{dm.MilitaryRank.AcrRankPl} {dm.FirstName} {dm.LastName} /{dm.OpNo}/"));
            
            CreateMap<GroupForDayRep, GetAllGroupsViewModel>()
                .ForMember(vm => vm.GroupId, 
                    opt => 
                        opt.MapFrom(dm => dm.Id))
                .ForMember(vm => vm.GroupName, 
                    opt => 
                        opt.MapFrom(dm => dm.Name));

            CreateMap<EduBlock, EduBlockViewModel>()
                .ForMember(vm => vm.ToDisplay,
                    opt =>
                        opt.MapFrom(dm =>
                            $"{dm.AssignedTrainingGroups.First().TrainingGroup.Name} {dm.EduBlockSubject.Subject}"));
            
            CreateMap<EduBlock, EduBlockViewModelForMedical>()
                .ForMember(vm => vm.ToDisplay,
                    opt =>
                        opt.MapFrom(dm =>
                            $"{dm.AssignedTrainingGroups.First().TrainingGroup.Name} {dm.EduBlockSubject.Subject}"));

            CreateMap<EduBlock, EduBlockToApproveViewModel>()
                .ForMember(vm => vm.Subject,
                    opt =>
                        opt.MapFrom(dm => dm.EduBlockSubject.Subject)).ForMember(
                    vm => vm.GroupName, opt =>
                        opt.MapFrom(dm => dm.AssignedTrainingGroups.First().TrainingGroup.Name)).ForMember(
                    vm => vm.AssignedFacilityName, opt =>
                        opt.MapFrom(dm => dm.AssignedTrainingFacilities.First().TrainingFacility.Name ?? 
                                          dm.TrainingFacility));

            CreateMap<TrainingFacility, TrainingFacilityViewModel>()
                .ForMember(vm => vm.ToDisplay,
                    opt =>
                        opt.MapFrom(dm => $"{dm.Name} {dm.Location}"));

            CreateMap<TrainingArea, TrainingAreaDetailViewModel>()
                .ForMember(vm => vm.EduBlockSubjects,
                opt =>
                    opt.MapFrom(dm => dm.EduBlockSubjects));
            
            CreateMap<Person, PersonViewModel>()
                .ForMember(vm => vm.FullName,
                opt => 
                    opt.MapFrom(dm => dm.MilitaryRankId == null ? $"{dm.FirstName} {dm.LastName}" : 
                        $"{dm.MilitaryRank.AcrRankPl} {dm.FirstName} {dm.LastName} /{dm.OpNo}/"));
            
            CreateMap<Person, PersonForManagementViewModel>()
                .ForMember(vm => vm.PersonId, 
                    opt => 
                        opt.MapFrom(dm => dm.Id))
                .ForMember(vm => vm.PersonFullData,
                    opt => 
                        opt.MapFrom(dm => dm.MilitaryRankId == null ? $"{dm.FirstName} {dm.LastName}" : 
                            $"{dm.MilitaryRank.AcrRankPl} {dm.FirstName} {dm.LastName} /{dm.OpNo}/"));
            
            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(vm => vm.VehicleType, 
                    opt => 
                        opt.MapFrom(dm => dm.VehicleType.ToString()))
                .ForMember(vm => vm.Name,
                opt =>
                    opt.MapFrom(dm => $"{dm.Brand} {dm.Model} {dm.RegisterNumber}"));
            
            CreateMap<CurrentAmmoLimitsForDepartment, CurrentLimitViewModel>()
                .ForMember(vm => vm.Ammo, 
                    opt => 
                        opt.MapFrom(dm => dm.Ammo.Name));
            
            CreateMap<UnitDepartment, UnitDepartmentDetailViewModel>()
                .ForMember(vm => vm.Limits, 
                    opt => 
                        opt.MapFrom(dm => dm.CurrentAmmoLimitsForDepartments));
            
            CreateMap<CurrentAmmoLimitsForDepartment, AmmoDetailToDepartmentViewModel>()
                .ForMember(vm => vm.Ammo, 
                    opt => 
                        opt.MapFrom(dm => dm.Ammo.Name));
            
            CreateMap<UnitDepartment, UnitDepartmentWithAmmoDetailViewModel>()
                .ForMember(vm => vm.Limits, 
                    opt => 
                        opt.MapFrom(dm => dm.CurrentAmmoLimitsForDepartments));
            
            // REFACTOR DAPPER!!!
            CreateMap<TrainingGroup, TrainingGroupForManagementViewModel>()
                .ForMember(vm => vm.GroupId,
                    opt =>
                        opt.MapFrom(dm => dm.Id))
                .ForMember(vm => vm.GroupName,
                    opt =>
                        opt.MapFrom(dm => dm.Name))
                .ForMember(vm => vm.ListOfPersonnelForGroups,
                    opt =>
                        opt.MapFrom(dm => dm.TrainingGroupsPersons));

            CreateMap<TrainingGroupPerson, PersonForGroupViewModel>()
                .ForMember(vm => vm.PersonInGroupId,
                    opt =>
                        opt.MapFrom(dm => dm.Id))
                .ForMember(vm => vm.FullName,
                    opt =>
                        opt.MapFrom(dm =>
                            dm.Person.MilitaryRankId == null
                                ? $"{dm.Person.FirstName} {dm.Person.LastName}"
                                : $"{dm.Person.MilitaryRank.AcrRankPl} {dm.Person.FirstName} {dm.Person.LastName} /{dm.Person.OpNo}/"))
                .ForMember(vm => vm.NoOp,
                    opt =>
                        opt.MapFrom(dm => dm.Person.OpNo))
                .ForMember(vm => vm.OtherGroupStatus,
                    opt =>
                        opt.MapFrom(dm => dm.TrainingGroup.Name));
            // .ForMember(vm => vm.OtherGroupStatus,
            //     opt =>
            //         opt.MapFrom(dm => ?)); I DON'T KNOW -> HelpWithGetOtherTrainingGroupForPerson!!!
        }
    }
}