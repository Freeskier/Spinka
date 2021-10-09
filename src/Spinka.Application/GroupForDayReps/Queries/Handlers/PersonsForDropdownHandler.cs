using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Spinka.Application.GroupForDayReps.Queries.Handlers
{
    public class PersonsForDropdownHandler : IQueryHandler<PersonsForDropdownQuery, IEnumerable<PersonsForDropdownViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public PersonsForDropdownHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<PersonsForDropdownViewModel>> HandleAsync(PersonsForDropdownQuery query)
        {
            // DAPPER!!!
            var usedPersonInGroup = await _unitOfWork.Repository<DayRepGroupPerson>()
                .FindAllAsync(x => x.GroupForDayRepId == query.DayRepGroupId && x.IsDeleted == false);
            
            var resultAux = await _unitOfWork.Repository<Person>()
                .FindAllAsync(x=> usedPersonInGroup.Select(y => y.PersonId)
                    .Contains(x.Id));
            
            var result = await _unitOfWork.Repository<Person>()
                .GetAllWithIncludesAsync(i => i.Include(x => x.MilitaryRank));
            result = result.Except(resultAux);

            return _mapper.Map<IEnumerable<PersonsForDropdownViewModel>>(result);
        }
    }
}
