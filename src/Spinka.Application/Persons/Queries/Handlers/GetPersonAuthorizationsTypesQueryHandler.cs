using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Application.Persons.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.Persons.Queries.Handlers
{
    public class GetPersonAuthorizationsTypesQueryHandler : IQueryHandler<GetPersonAuthorizationsType, IEnumerable<PersonAuthorizationsTypeViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<PersonAuthorization, PersonAuthorizationsTypeViewModel> _mapper;

        public GetPersonAuthorizationsTypesQueryHandler(IUnitOfWork unitOfWork, IMapper<PersonAuthorization, PersonAuthorizationsTypeViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonAuthorizationsTypeViewModel>> HandleAsync(GetPersonAuthorizationsType query)
        {
            var personAuthorizations = await _unitOfWork.Repository<PersonAuthorization>()
                .FindAllWithIncludesAsync(x => x.PersonId == query.UserId,
                    i => i.Include(x => x.AuthorizationsType ));
            personAuthorizations = personAuthorizations.Where(x => !x.IsDeleted);
            return personAuthorizations.Select(_mapper.MapObject).ToList();
        }
    }
}