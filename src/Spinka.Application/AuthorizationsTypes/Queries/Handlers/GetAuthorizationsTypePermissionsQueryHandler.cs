using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.AuthorizationsTypes.Queries.Handlers
{
    public class GetAuthorizationsTypePermissionsQueryHandler : IQueryHandler<GetAuthorizationsTypePermissions, IEnumerable<AuthorizationsTypePermissionViewModel>>
    {
        private readonly IMapper<AuthorizationsTypePermissions, AuthorizationsTypePermissionViewModel> _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAuthorizationsTypePermissionsQueryHandler(IMapper<AuthorizationsTypePermissions, AuthorizationsTypePermissionViewModel> mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AuthorizationsTypePermissionViewModel>> HandleAsync(GetAuthorizationsTypePermissions query)
        {
            var permissions = await _unitOfWork.Repository<AuthorizationsTypePermissions>()
                .FindAllWithIncludesAsync(x => x.AuthorizationsTypeId == query.AuthorizationTypeId,
                    i => i.Include(x => x.Permission));
            return permissions.Where(x => !x.Permission.IsDeleted).Where(x =>!x.IsDeleted).Select(_mapper.MapObject).ToList();
        }
    }
}