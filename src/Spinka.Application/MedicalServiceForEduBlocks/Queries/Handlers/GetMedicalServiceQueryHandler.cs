using System.Threading.Tasks;
using Dapper;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.MedicalServiceForEduBlocks.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.MedicalServiceForEduBlocks.Queries.Handlers
{
    public class GetMedicalServiceQueryHandler : IQueryHandler<GetMedicalService, MedicalServiceForEduBlockViewModel>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetMedicalServiceQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<MedicalServiceForEduBlockViewModel> HandleAsync(GetMedicalService query)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string medicalSql = "SELECT [MedicalServiceForEduBlock].[Id]," + 
                        "Driver = (SELECT IIF([Person].[MilitaryRankId] IS NOT NULL," +
                            "[MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'," +
                            "[Person].[FirstName] + ' ' + [Person].[LastName])" +
                            "FROM Persons AS [Person]" +
                            "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                            "WHERE [Person].[Id] = [MedicalServiceForEduBlock].[DriverPersonId]), " +
                        "Ambulance = (SELECT [Vehicle].[Brand] + ' ' + [Vehicle].[Model] + ' ' + [Vehicle].[RegisterNumber]" +
                            "FROM Vehicles AS [Vehicle]" +
                            "WHERE [Vehicle].[Id] = [MedicalServiceForEduBlock].[AmbulanceVehicleId])" +
                        "FROM EduBlocks AS [EduBlock]" +
                        "JOIN MedicalServiceForEduBlocks AS [MedicalServiceForEduBlock] ON [EduBlock].MedicalServiceForEduBlockId = [MedicalServiceForEduBlock].[Id]" +
                        "WHERE [EduBlock].[Id] = @EduBlockId";
            
            var medicalServiceForEduBlock = await connection.QuerySingleAsync<MedicalServiceForEduBlockViewModel>(
                medicalSql, new { query.EduBlockId });
            
            const string medicalStaffSql =  "SELECT [AssignedPersonToMedicalService].[PersonId] AS Id," + 
                        "IIF([Person].[MilitaryRankId] IS NOT NULL," +
                            "[MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'," +
                            "[Person].[FirstName] + ' ' + [Person].[LastName]) AS FullName, [AuthorizationsType].[Name] AS [Function]" + 
                        "FROM AssignedPersonToMedicalServices AS [AssignedPersonToMedicalService]" + 
                        "JOIN Persons AS [Person] ON [AssignedPersonToMedicalService].[PersonId] = [Person].[Id]" +
                        "LEFT JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                        "JOIN PersonAuthorisedForEduBlockFunctions AS [PersonAuthorisedForEduBlockFunction] ON [Person].[Id] = [PersonAuthorisedForEduBlockFunction].[PersonId]" +
                        "JOIN AuthorizationsTypes AS [AuthorizationsType] ON [PersonAuthorisedForEduBlockFunction].[AuthorisationsTypeId] = [AuthorizationsType].[Id]" +
                        "WHERE [PersonAuthorisedForEduBlockFunction].[AuthorisationsTypeId] IN(10,11) AND [AssignedPersonToMedicalService].[MedicalServiceForEduBlockId] = @Id";

            var medicalStaffToEduBlock = await connection.QueryAsync<AssignedPersonToMedicalServiceViewModel>(
                    medicalStaffSql, new {medicalServiceForEduBlock.Id});

            medicalServiceForEduBlock.MedicalStaff = medicalStaffToEduBlock;
            
            return medicalServiceForEduBlock;
        }
    }
}