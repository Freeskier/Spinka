using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Persons.ViewModels;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Persons.Queries.Handlers
{
    public class GetPersonWithPatternQueryHandler : IQueryHandler<GetPersonWithPattern, IEnumerable<PersonViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GetPersonWithPatternQueryHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        
        public async Task<IEnumerable<PersonViewModel>> HandleAsync(GetPersonWithPattern query)
        {
            if (query.Ids == null)
            {
                return await CacheHelper.GetValueFromCacheWithCondition<Person, PersonViewModel>(_unitOfWork, _memoryCache, _mapper, 
                    Consts.PersonKey, x => x.LastName.ToLowerInvariant().Contains(query.Pattern.ToLowerInvariant())
                    || x.FirstName.ToLowerInvariant().Contains(query.Pattern.ToLowerInvariant()) 
                    || x.OpNo.ToString().Contains(query.Pattern));
            }
            
            return await CacheHelper.GetValueFromCacheWithCondition<Person, PersonViewModel>(_unitOfWork, _memoryCache, _mapper, 
                Consts.PersonKey, x => (x.LastName.ToLowerInvariant().Contains(query.Pattern.ToLowerInvariant())
                                        || x.FirstName.ToLowerInvariant().Contains(query.Pattern.ToLowerInvariant()) 
                                        || x.OpNo.ToString().Contains(query.Pattern)) && !query.Ids.Contains(x.Id));
        }
    }
}