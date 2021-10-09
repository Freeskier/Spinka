using System.Threading.Tasks;
using Dapper;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.EduBlocks.Queries.Handlers
{
    public class GetEduBlockQueryHandler : IQueryHandler<GetEduBlock, EduBlockDetailViewModel>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEduBlockQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<EduBlockDetailViewModel> HandleAsync(GetEduBlock query)
        {
             var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string eduBlockSql = "SELECT [EduBlock].[Id]," +
                    "[EduBlock].[StartTime]," +
                    "[EduBlock].[EndOn]," + 
                    "Instructor = (SELECT IIF([Person].[MilitaryRankId] IS NOT NULL," +
                         "[MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'," +
                         "[Person].[FirstName] + ' ' + [Person].[LastName])" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[InstructorPersonId])," +
                    "[EduBlock].[InstructorPersonId] AS [InstructorId],"+
                    "ShootingInstructor = (SELECT [MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[ShootingInstructorPersonId])," +
                    "[EduBlock].[ShootingInstructorPersonId] AS [ShootingInstructorId]," +
                    "AmmoManager = (SELECT [MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[AmmoManagerPersonId])," +
                    "[EduBlock].[AmmoManagerPersonId] AS [AmmoManagerId]," +
                    "[EduBlock].[LastUpdateDateTime]," +
                    "LastUpdatePersonEduBlock = (SELECT IIF([Person].[MilitaryRankId] IS NOT NULL," +
                         "[MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'," +
                         "[Person].[FirstName] + ' ' + [Person].[LastName])" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[LastUpdatePersonId])," +
                    "[EduBlock].[LastUpdatePersonId] AS [LastUpdatePersonEduBlockId]," +
                    "CreatedBy = (SELECT IIF([Person].[MilitaryRankId] IS NOT NULL," +
                         "[MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'," +
                         "[Person].[FirstName] + ' ' + [Person].[LastName])" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[CreatedByPersonId])," +
                    "[EduBlock].[CreatedByPersonId] AS [CreatedById]," +
                    "Driver1 = (SELECT [MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[DriverPersonId1])," +
                    "[EduBlock].[DriverPersonId1] AS [Driver1Id]," +
                    "Driver2 = (SELECT [MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[DriverPersonId2])," +
                    "[EduBlock].[DriverPersonId2] AS [Driver2Id]," +
                    "ExplosivesManager = (SELECT [MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[ExplosivesManagerPersonId])," +
                    "[EduBlock].[ExplosivesManagerPersonId] AS [ExplosivesManagerId]," +
                    "SecurityPerson = (SELECT [MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[SecurityPersonId])," +
                    "[EduBlock].[SecurityPersonId] AS [SecurityPersonId]," +
                    "[EduBlock].[Approved]," +
                    "ApprovedBy = (SELECT IIF([Person].[MilitaryRankId] IS NOT NULL," +
                         "[MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'," +
                         "[Person].[FirstName] + ' ' + [Person].[LastName])" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "WHERE [Person].[Id] = [EduBlock].[ApprovedByPersonId])," +
                    "[EduBlock].[ApprovedByPersonId] AS [ApprovedById]," +
                    "[EduBlock].[ApprovedTime]," +
                    "[EduBlock].[IsMedicalServiceRequired]," +
                    "[TrainingArea].[Name] AS [TrainingArea]," +
                    "[TrainingArea].[Id] AS [TrainingAreaId]," +
                    "[TrainingArea].[TrainingAcronym] AS [TrainingAcronym]," +
                    "[EduBlockSubject].[Subject] AS [EduBlockSubject]," +
                    "[EduBlockSubject].[Id] AS [EduBlockSubjectId]," +
                    "[EduBlock].[TrainingFacility]," +
                    "[EduBlock].[IsCancelled]," +
                    "[EduBlock].[CancellReason]," +
                    "[EduBlock].[AdditionalInformation]" +
                    "FROM EduBlocks AS [EduBlock]" +
                    "JOIN EduBlockSubjects AS [EduBlockSubject] ON [EduBlockSubject].[Id] = [EduBlock].[EduBlockSubjectId]" +
                    "JOIN TrainingAreas AS [TrainingArea] ON [TrainingArea].[Id] = [EduBlockSubject].[TrainingAreaId]" +
                    "WHERE [EduBlock].[Id] = @Id";

            var eduBlock = await connection.QuerySingleOrDefaultAsync<EduBlockDetailViewModel>(eduBlockSql, new { query.Id });
            
            const string auxPersonSql = "SELECT [Person].[Id]," + 
                         "FullName = [MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "JOIN AuxPersonForEduBlocks AS [AuxPersonForEduBlock] ON [Person].[Id] = [AuxPersonForEduBlock].[PersonId]" +
                         "WHERE [AuxPersonForEduBlock].[EduBlockId] = @Id";

            eduBlock.AuxPersons = await connection.QueryAsync<AuxPersonForEduBlockViewModel>(auxPersonSql, new { query.Id });
            
            const string assistantInstructorsSql = "SELECT [Person].[Id]," + 
                         "FullName = [MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'" +
                         "FROM Persons AS [Person]" +
                         "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                         "JOIN AssignedAssistantInstructors AS [AssignedAssistantInstructor] ON [Person].[Id] = [AssignedAssistantInstructor].[PersonId]" +
                         "WHERE [AssignedAssistantInstructor].[EduBlockId] = @Id";
            
            eduBlock.AssignedAssistantInstructors = await connection.QueryAsync<AssignedAssistantInstructorToEduBlockViewModel>(assistantInstructorsSql, new { query.Id });
            
            const string trainingGroupsSql = "SELECT [AssignedTrainingGroup].[TrainingGroupId] AS [Id]," + 
                         "[TrainingGroup].[Name]" +
                         "FROM AssignedTrainingGroups AS [AssignedTrainingGroup]" +
                         "JOIN TrainingGroups AS [TrainingGroup] ON [TrainingGroup].[Id] = [AssignedTrainingGroup].[TrainingGroupId]" +
                         "WHERE [AssignedTrainingGroup].[EduBlockId] = @Id";

            eduBlock.AssignedTrainingGroups = await connection.QueryAsync<AssignedTrainingGroupToEduBlockViewModel>(trainingGroupsSql, new { query.Id });

            const string trainingFacilitiesSql = "SELECT [AssignedTrainingFacility].[TrainingFacilityId] AS [Id]," + 
                         "[TrainingFacility].[Name]," +
                         "[TrainingFacility].[Location]," +
                         "[AssignedTrainingFacility].[StartTime] AS [Start]," +
                         "[AssignedTrainingFacility].[EndOn] AS [End]" +
                         "FROM AssignedTrainingFacilities AS [AssignedTrainingFacility]" + 
                         "JOIN TrainingFacilities AS [TrainingFacility] ON [TrainingFacility].[Id] = [AssignedTrainingFacility].[TrainingFacilityId]" +
                         "WHERE [AssignedTrainingFacility].[EduBlockId] = @Id";
            
            eduBlock.AssignedTrainingFacilities = await connection.QueryAsync<AssignedTrainingFacilityToEduBlockViewModel>(trainingFacilitiesSql, new { query.Id });

            const string vehiclesSql = "SELECT [AssignedVehicle].[VehicleId] AS [Id]," + 
                         "[Vehicle].[Brand]," +  
                         "[Vehicle].[Model]," + 
                         "[Vehicle].[RegisterNumber]," + 
                         "[Vehicle].[VehicleType]" +
                         "FROM AssignedVehicles AS [AssignedVehicle]" +
                         "JOIN Vehicles AS [Vehicle] ON [Vehicle].[Id] = [AssignedVehicle].[VehicleId]" +
                         "WHERE [AssignedVehicle].[EduBlockId] = @Id";
            
            eduBlock.AssignedVehicles = await connection.QueryAsync<AssignedVehicleToEduBlockViewModel>(vehiclesSql, new { query.Id });

            const string ammoSql = "SELECT [AA].[AmmoId] AS [Id]," +
                         "[A].[Name] AS [Name]," +
                         "[MeasureUnit].[Acronym] AS [MeasureUnit]," +
                         "[AA].Quantity AS [Quantity]," +
                         "[CurrentAmmoLimitsForDepartment].Quantity AS [Limit]" +
                         "FROM AssignedAmmo AS [AA]" +
                         "JOIN Ammo AS [A] ON [A].[Id] = [AA].[AmmoId]" +
                         "JOIN CurrentAmmoLimitsForDepartments AS [CurrentAmmoLimitsForDepartment] ON [A].[Id] = [CurrentAmmoLimitsForDepartment].[AmmoId]" +
                         "JOIN MeasureUnits AS [MeasureUnit] on [MeasureUnit].[Id] = [A].[MeasureUnitId]" +
                         "WHERE EduBlockId = @Id " +
                              "AND [CurrentAmmoLimitsForDepartment].[UnitDepartmentsId] = (SELECT [TrainingGroupsInDepartment].[UnitDepartmentsId]" +
                                   "FROM TrainingGroupsInDepartments AS [TrainingGroupsInDepartment]" +
                                   "WHERE [TrainingGroupsInDepartment].[TrainingGroupId] " +
                                   "IN (SELECT TOP 1 [AssignedTrainingGroup].[TrainingGroupId]" +
                                        "FROM AssignedTrainingGroups AS [AssignedTrainingGroup]))";
            
            eduBlock.AssignedAmmo = await connection.QueryAsync<AssignedAmmoToEduBlockViewModel>(ammoSql, new { query.Id });

            return eduBlock;
        }
    }
}