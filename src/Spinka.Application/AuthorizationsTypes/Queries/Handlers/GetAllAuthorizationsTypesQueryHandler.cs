using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingAreas.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.AuthorizationsTypes.Queries.Handlers
{
    public class GetAllAuthorizationsTypesQueryHandler : IQueryHandler<GetAllAuthorizationsTypes, IEnumerable<AuthorizationsTypeViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<AuthorizationsType, AuthorizationsTypeViewModel> _mapper;

        public GetAllAuthorizationsTypesQueryHandler(IUnitOfWork unitOfWork, IMapper<AuthorizationsType, AuthorizationsTypeViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorizationsTypeViewModel>> HandleAsync(GetAllAuthorizationsTypes query)
        {
            var authorizationsTypes = await _unitOfWork.Repository<AuthorizationsType>().GetAllAsync();
            return authorizationsTypes.Where(x => !x.IsDeleted).Select(_mapper.MapObject).ToList();
        }
    }
}