using System.Threading.Tasks;
using Dapper;
using Spinka.Application.AssignedTrainingFacilities.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.AssignedTrainingFacilities.Queries.Handlers
{
    public class GetAssignedTrainingFacilityQueryHandler : IQueryHandler<GetAssignedTrainingFacility, AssignedTrainingFacilitiesViewModel>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAssignedTrainingFacilityQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<AssignedTrainingFacilitiesViewModel> HandleAsync(GetAssignedTrainingFacility query)
        { 
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT [AssignedTrainingFacility].[Id]," +
                    "[AssignedTrainingFacility].[TrainingFacilityId]," +
                    "[AssignedTrainingFacility].[EduBlockId]," +
                    "[AssignedTrainingFacility].[StartTime]," +
                    "[AssignedTrainingFacility].[EndOn]," +
                    "[TrainingFacility].[Name]," +
                    "MainInstructor =  (SELECT IIF([Person].[MilitaryRankId] IS NOT NULL," +
                        "[MilitaryRank].[AcrRankPl] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] + ' /' + CAST([Person].[OpNo] AS VARCHAR(5)) + '/'," +
                        "[Person].[FirstName] + ' ' + [Person].[LastName])" +
                        "FROM Persons AS [Person]" +
                        "JOIN MilitaryRanks AS [MilitaryRank] ON [MilitaryRank].[Id] = [Person].[MilitaryRankId]" +
                        "WHERE [Person].[Id] = [EduBlock].[InstructorPersonId])," +
                    "TrainingArea = (SELECT [TrainingArea].[Name]" +
                        "FROM EduBlockSubjects AS [EduBlockSubject]" +
                        "JOIN TrainingAreas AS [TrainingArea] ON [TrainingArea].[Id] = [EduBlockSubject].[TrainingAreaId]" +
                        "WHERE [EduBlockSubject].[Id] = [EduBlock].[EduBlockSubjectId])," +
                    "MainGroup = (SELECT TOP 1 [TrainingGroup].[Name]" +
                        "FROM TrainingGroups AS [TrainingGroup]" +
                        "JOIN AssignedTrainingGroups AS [AssignedTrainingGroup] ON [TrainingGroup].[Id] = [AssignedTrainingGroup].[TrainingGroupId]" +
                        "WHERE [AssignedTrainingGroup].[EduBlockId] = [EduBlock].[Id])" +
                    "FROM AssignedTrainingFacilities AS [AssignedTrainingFacility]" +
                    "JOIN EduBlocks AS [EduBlock] ON [EduBlock].Id = [AssignedTrainingFacility].[EduBlockId]" +
                    "JOIN TrainingFacilities AS [TrainingFacility] ON [AssignedTrainingFacility].[TrainingFacilityId] = [TrainingFacility].[Id]" +
                    "WHERE [EduBlock].[IsDeleted] = 'false' AND [AssignedTrainingFacility].[Id] = @Id";

            return await connection.QuerySingleOrDefaultAsync<AssignedTrainingFacilitiesViewModel>(sql, new { query.Id });
        }
    }
}