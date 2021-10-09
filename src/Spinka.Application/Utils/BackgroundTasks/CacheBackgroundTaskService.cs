using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Utils.BackgroundTasks
{
    public class CacheBackgroundTaskService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CacheBackgroundTaskService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await LoadDataToCacheAsync();
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
        
        private async Task LoadDataToCacheAsync()
        {
            using var scope = _scopeFactory.CreateScope();
            var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var cache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();

            await CacheHelper.SetCache<Vehicle>(uow, cache, Consts.VehicleKey, null);
            await CacheHelper.SetCache<Person>(uow, cache, Consts.PersonKey, 
                i => i.Include(x => x.MilitaryRank));
            await CacheHelper.SetCache<MilitaryRank>(uow, cache, Consts.MilitaryRankKey, null);
            await CacheHelper.SetCache<TrainingGroup>(uow, cache, Consts.TrainingGroupKey,null);
            await CacheHelper.SetCache<TrainingArea>(uow, cache, Consts.TrainingAreaKey, null);
            await CacheHelper.SetCache<EduBlockSubject>(uow, cache, Consts.EduBlockSubjectKey, null);
            await CacheHelper.SetCache<UnitDepartment>(uow, cache, Consts.UnitDepartmentKey, null);
            await CacheHelper.SetCache<TrainingFacility>(uow, cache, Consts.TrainingFacilityKey, null);
            await CacheHelper.SetCache<AmmoTransactionType>(uow, cache, Consts.AmmoTransactionTypeKey, null);
            await CacheHelper.SetCache<AmmoType>(uow, cache, Consts.AmmoTypeKey, null);
            await CacheHelper.SetCache<MeasureUnit>(uow, cache, Consts.MeasureUnitKey, null);
        }
    }
}