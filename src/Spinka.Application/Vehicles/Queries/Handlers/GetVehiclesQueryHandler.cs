using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Application.Vehicles.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Vehicles.Queries.Handlers
{
    public class GetVehiclesQueryHandler : IQueryHandler<GetVehicles, IEnumerable<VehicleViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GetVehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<VehicleViewModel>> HandleAsync(GetVehicles query)
            => await CacheHelper.GetValueFromCache<Vehicle, VehicleViewModel>(_unitOfWork, _memoryCache, 
                _mapper, Consts.VehicleKey, null);
    }
}