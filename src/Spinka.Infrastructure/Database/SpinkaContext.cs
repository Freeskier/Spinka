using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Spinka.Domain.Models;
using Spinka.Domain.Models.ProcedureModels;
using Spinka.Infrastructure.Options;

namespace Spinka.Infrastructure.Database
{
    public class SpinkaContext : DbContext
    {
        private readonly IOptions<SqlOption> _sqlOption;
        

        #region DbSets

        public DbSet<AdditionalPersonnel> AdditionalPersonnel { get; set; }
        public DbSet<Ammo> Ammo { get; set; }
        public DbSet<AmmoTransaction> AmmoTransactions { get; set; }
        public DbSet<AmmoTransactionType> AmmoTransactionTypes { get; set; }
        public DbSet<AmmoType> AmmoTypes { get; set; }
        public DbSet<AssignedAmmo> AssignedAmmo { get; set; }
        public DbSet<AssignedAssistantInstructor> AssignedAssistantInstructors { get; set; }
        public DbSet<AssignedAvailabilityType> AssignedAvailabilityTypes { get; set; }
        public DbSet<AssignedPersonToMedicalService> AssignedPersonToMedicalServices { get; set; }
        public DbSet<AssignedTrainingFacility> AssignedTrainingFacilities { get; set; }
        public DbSet<AssignedTrainingGroup> AssignedTrainingGroups { get; set; }
        public DbSet<AssignedVehicle> AssignedVehicles { get; set; }
        public DbSet<AuthorizationsType> AuthorizationsTypes { get; set; }
        public DbSet<AuxPersonForEduBlock> AuxPersonForEduBlocks { get; set; }
        public DbSet<AvailabilityRole> AvailabilityRoles { get; set; }
        public DbSet<AvailabilityType> AvailabilityTypes { get; set; }
        public DbSet<CurrentAmmoLimitsForDepartment> CurrentAmmoLimitsForDepartments { get; set; }
        public DbSet<DayRep> DayReps { get; set; }
        public DbSet<DayRepAcronym> DayRepAcronyms { get; set; }
        public DbSet<DayRepGroupPerson> DayRepGroupPersons { get; set; }
        public DbSet<EduBlock> EduBlocks { get; set; }
        public DbSet<EduBlockControl> EduBlockControls { get; set; }
        public DbSet<EduBlockSubject> EduBlockSubjects { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<FunctionForEduBlock> FunctionForEduBlocks { get; set; }
        public DbSet<GroupForDayRep> GroupForDayReps { get; set; }
        public DbSet<MajorEvent> MajorEvents { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<MedicalServiceForEduBlock> MedicalServiceForEduBlocks { get; set; }
        public DbSet<MilitaryRank> MilitaryRanks { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonAuthorisedForEduBlockFunction> PersonAuthorisedForEduBlockFunctions { get; set; }
        public DbSet<PersonAuthorization> PersonAuthorizations { get; set; }
        public DbSet<TrainingArea> TrainingAreas { get; set; }
        public DbSet<TrainingFacility> TrainingFacilities { get; set; }
        public DbSet<TrainingGroup> TrainingGroups { get; set; }
        public DbSet<TrainingGroupsInDepartment> TrainingGroupsInDepartments { get; set; }
        public DbSet<TrainingGroupsPerson> TrainingGroupsPersons { get; set; }
        public DbSet<UnitDepartment> UnitDepartments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<AuthorizationsTypePermissions> AuthorizationsTypePermissions { get; set; }
        
        #region ProcedureDbSets
        public DbSet<DayRepCalendarForGroupProcedure> DayRepCalendarForGroupProcedures { get; set; }

        public DbSet<DayRepCalendarForGroupProcedureText> DayRepCalendarForGroupProcedureText { get; set; }
        public DbSet<DayRepNumbersForGroupInnerDashBoardProcedure> DayRepNumbersForGroupInnerDashBoardProcedure { get; set; }
        
        #endregion
        
        #endregion

        public SpinkaContext(IOptions<SqlOption> sqlOption)
        {
            _sqlOption = sqlOption;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(_sqlOption.Value.ConnectionString, options =>
                options.MigrationsAssembly("Spinka.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
