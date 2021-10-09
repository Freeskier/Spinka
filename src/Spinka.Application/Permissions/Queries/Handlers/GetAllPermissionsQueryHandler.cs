using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Permissions.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.Permissions.Queries.Handlers
{
    public class GetAllPermissionsQueryHandler : IQueryHandler<GetAllPermissions, IEnumerable<PermissionViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Permission, PermissionViewModel> _mapper;

        public GetAllPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper<Permission, PermissionViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionViewModel>> HandleAsync(GetAllPermissions query)
        {
            var permissions = await _unitOfWork.Repository<Permission>().GetAllAsync();
            return permissions.Select(_mapper.MapObject).ToList();
        }
    }
}