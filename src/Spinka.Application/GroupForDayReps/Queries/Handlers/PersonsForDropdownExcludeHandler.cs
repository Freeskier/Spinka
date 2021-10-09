using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Spinka.Application.Utils.Helpers;

namespace Spinka.Application.GroupForDayReps.Queries.Handlers
{
    public class PersonsForDropdownExcludeHandler : IQueryHandler<PersonsForDropdownExcludeQuery, IEnumerable<PersonsForDropdownViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Person, PersonsForDropdownViewModel> _mapper;
        public PersonsForDropdownExcludeHandler(IUnitOfWork unitOfWork,
                                        IMapper<Person, PersonsForDropdownViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       
        public async Task<IEnumerable<PersonsForDropdownViewModel>> HandleAsync(PersonsForDropdownExcludeQuery query)
        {
            var requestedGroup = await _unitOfWork.Repository<DayRepGroupPerson>().FindAllAsync(x => x.GroupForDayRepId == query.DayRepGroupId && x.IsDeleted == false);
            var personnelFromGroup = await _unitOfWork.Repository<Person>().FindAllAsync(x=> requestedGroup.Select(x => x.PersonId).Contains(x.Id));
            var result = await _unitOfWork.Repository<Person>().FindAllAsync(
                x=> x.LastName.Contains(query.SearchString) ||
                 x.FirstName.Contains(query.SearchString) ||
                 x.OpNo.ToString().Contains(query.SearchString) 
                );
            result = result.Except(personnelFromGroup).OrderBy(x=>x.LastName);

            return result.Select(_mapper.MapObject).ToList();
        }
    }
}
