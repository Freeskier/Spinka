using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Spinka.Application.Ammo.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Infrastructure.Database;
using AmmoEntity = Spinka.Domain.Models.Ammo;

namespace Spinka.Application.Ammo.Queries.Handlers
{
    public class GetLimitAmmoQueryHandler : IQueryHandler<GetLimitAmmo, IEnumerable<AmmoDetailViewModel>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetLimitAmmoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<IEnumerable<AmmoDetailViewModel>> HandleAsync(GetLimitAmmo query)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT [A].[Id]," + 
                    "[A].[Name], [A].[LogIndex]," +
                    "[A].[IsDangerous]," + 
                    "[AmmoType].[Name] AS AmmoType," + 
                    "[MeasureUnit].[Acronym] AS MeasureUnit," + 
                    "[CurrentAmmoLimitsForDepartment].[Quantity]," +
                    "[UnitDepartment].[Name] AS UnitDepartment," + 
                    "TrainingGroup = (SELECT [TrainingGroup].[Name]" +
                        "FROM TrainingGroups AS [TrainingGroup]" +
                        "WHERE [TrainingGroup].[Id] = [TrainingGroupsInDepartment].[TrainingGroupId])," +
                    "[A].[Name] + ' ' + CAST([CurrentAmmoLimitsForDepartment].[Quantity] AS VARCHAR(15)) + '' + [MeasureUnit].[Acronym] AS [DisplayName]" +
                    "FROM Ammo AS [A]" +
                    "JOIN AmmoTypes AS [AmmoType] ON [AmmoType].[Id] = [A].[AmmoTypeId]" +
                    "JOIN MeasureUnits AS [MeasureUnit] ON [MeasureUnit].[Id] = [A].[MeasureUnitId]" +
                    "JOIN CurrentAmmoLimitsForDepartments AS [CurrentAmmoLimitsForDepartment] ON [CurrentAmmoLimitsForDepartment].[AmmoId] = [A].[Id]" +
                    "JOIN UnitDepartments AS [UnitDepartment] ON [UnitDepartment].[Id] = [CurrentAmmoLimitsForDepartment].[UnitDepartmentsId]" +
                    "JOIN TrainingGroupsInDepartments AS [TrainingGroupsInDepartment] ON [TrainingGroupsInDepartment].[UnitDepartmentsId] = [UnitDepartment].[Id]" +
                    "WHERE [TrainingGroupsInDepartment].[TrainingGroupId] = @GroupId";

            return await connection.QueryAsync<AmmoDetailViewModel>(sql, new {query.GroupId});
        }
    }
}