using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using TrainingGroupPerson = Spinka.Domain.Models.TrainingGroupsPerson;

namespace Spinka.Application.TrainingGroups.Queries.Handlers
{
    public class GetPersonForManagementQueryHandler : IQueryHandler<GetPersonForManagement, IEnumerable<PersonForManagementViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonForManagementQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<PersonForManagementViewModel>> HandleAsync(GetPersonForManagement query)
        { 
            // DAPPER!!!
            var usedPersonInGroup = await _unitOfWork.Repository<TrainingGroupPerson>()
                .FindAllAsync(x => x.TrainingGroupId == query.GroupId && !x.IsDeleted);
            
            var resultAux = await _unitOfWork.Repository<Person>()
                .FindAllAsync(x => usedPersonInGroup.Select(y => y.PersonId)
                    .Contains(x.Id));
            
            var result = await _unitOfWork.Repository<Person>()
                .GetAllWithIncludesAsync(i => i.Include(x => x.MilitaryRank));
            result = result.Except(resultAux);

            return _mapper.Map<IEnumerable<PersonForManagementViewModel>>(result);
        }
    }
}