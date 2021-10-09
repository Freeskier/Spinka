using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Permissions.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.Permissions.Queries.Handlers
{
    public class GetPersonPermissionsQueryHandler : IQueryHandler<GetPersonPermissions, IEnumerable<PermissionViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Permission, PermissionViewModel> _mapper;

        public GetPersonPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper<Permission, PermissionViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionViewModel>> HandleAsync(GetPersonPermissions query)
        {
            var personAuthorizations = await _unitOfWork.Repository<PersonAuthorization>()
                .FindAllWithIncludesAsync(x => x.PersonId == query.PersonId,
                    i => i.Include(x => x.AuthorizationsType ));
            personAuthorizations = personAuthorizations.Where(x => !x.IsDeleted);
            var permissions = new List<Permission>();
            foreach (var authorizationsType in personAuthorizations)
            {
                var permis = await _unitOfWork.Repository<AuthorizationsTypePermissions>()
                    .FindAllWithIncludesAsync(x => x.AuthorizationsTypeId == authorizationsType.AuthorizationTypeId,
                        i => i.Include(x => x.Permission));
                var authorizationsTypePermissionsEnumerable = permis.ToList();
                permissions.AddRange(authorizationsTypePermissionsEnumerable.Select(x =>x.Permission).Where(x => !x.IsDeleted));
            }

            return permissions.Select(_mapper.MapObject).ToList();
        }
    }
}