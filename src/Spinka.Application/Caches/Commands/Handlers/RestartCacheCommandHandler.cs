using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Caches.Commands.Handlers
{
    public class RestartCacheCommandHandler : ICommandHandler<RestartCache>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public RestartCacheCommandHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }
        
        public async Task HandleAsync(RestartCache command)
        {
            await CacheHelper.SetCache<Vehicle>(_unitOfWork, _memoryCache, Consts.VehicleKey, null);
            await CacheHelper.SetCache<Person>(_unitOfWork, _memoryCache, Consts.PersonKey, 
                i => i.Include(x => x.MilitaryRank));
            await CacheHelper.SetCache<MilitaryRank>(_unitOfWork, _memoryCache, Consts.MilitaryRankKey, null);
            await CacheHelper.SetCache<TrainingGroup>(_unitOfWork, _memoryCache, Consts.TrainingGroupKey, null);
            await CacheHelper.SetCache<TrainingArea>(_unitOfWork, _memoryCache, Consts.TrainingAreaKey, null);
            await CacheHelper.SetCache<EduBlockSubject>(_unitOfWork, _memoryCache, Consts.EduBlockSubjectKey, null);
            await CacheHelper.SetCache<UnitDepartment>(_unitOfWork, _memoryCache, Consts.UnitDepartmentKey, null);
            await CacheHelper.SetCache<TrainingFacility>(_unitOfWork, _memoryCache, Consts.TrainingFacilityKey, null);
            await CacheHelper.SetCache<AmmoTransactionType>(_unitOfWork, _memoryCache, Consts.AmmoTransactionTypeKey, null);
            await CacheHelper.SetCache<AmmoType>(_unitOfWork, _memoryCache, Consts.AmmoTypeKey, null);
            await CacheHelper.SetCache<MeasureUnit>(_unitOfWork, _memoryCache, Consts.MeasureUnitKey, null);
        }
    }
}