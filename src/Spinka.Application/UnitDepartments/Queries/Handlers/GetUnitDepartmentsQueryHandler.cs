using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.UnitDepartments.ViewModels;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.UnitDepartments.Queries.Handlers
{
    public class GetUnitDepartmentsQueryHandler : IQueryHandler<GetUnitDepartments, IEnumerable<UnitDepartmentViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public GetUnitDepartmentsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }
        
        public async Task<IEnumerable<UnitDepartmentViewModel>> HandleAsync(GetUnitDepartments query)
        {
            return await CacheHelper.GetValueFromCache<UnitDepartment, UnitDepartmentViewModel>(_unitOfWork,
                _memoryCache, _mapper, Consts.UnitDepartmentKey, null);
        }
    }
}