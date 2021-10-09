using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Persons.ViewModels;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Persons.Queries.Handlers
{
    public class GetPersonsQueryHandler : IQueryHandler<GetPersons, IEnumerable<PersonViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GetPersonsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        
        public async Task<IEnumerable<PersonViewModel>> HandleAsync(GetPersons query)
            => await CacheHelper.GetValueFromCache<Person, PersonViewModel>(_unitOfWork, _memoryCache, _mapper, Consts.PersonKey, 
                i => i.Include(x => x.MilitaryRank));
    }
}