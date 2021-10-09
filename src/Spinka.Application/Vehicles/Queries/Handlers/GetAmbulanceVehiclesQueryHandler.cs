using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Application.Vehicles.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Models.Enums;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Vehicles.Queries.Handlers
{
    public class GetAmbulanceVehiclesQueryHandler : IQueryHandler<GetAmbulanceVehicles, IEnumerable<VehicleViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GetAmbulanceVehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<VehicleViewModel>> HandleAsync(GetAmbulanceVehicles query)
            => await CacheHelper.GetValueFromCacheWithCondition<Vehicle, VehicleViewModel>(_unitOfWork, _memoryCache, 
                _mapper, Consts.VehicleKey, x => x.VehicleType == VehicleType.Ambulance);
    }
}