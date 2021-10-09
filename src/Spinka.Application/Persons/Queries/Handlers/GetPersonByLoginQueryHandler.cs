using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Application.Persons.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.Persons.Queries.Handlers
{
    public class GetPersonByLoginQueryHandler : IQueryHandler<GetPersonByLogin, PersonByLoginViewModel>
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Person, PersonByLoginViewModel> _mapper;

        public GetPersonByLoginQueryHandler(IUnitOfWork unitOfWork, IMapper<Person, PersonByLoginViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonByLoginViewModel> HandleAsync(GetPersonByLogin query)
        {
            var p = await _unitOfWork.Repository<Person>().GetOrFailAsync(x => x.Login == query.Login);
            /*var person = await _unitOfWork.Repository<Person>()
                .FindByAsync(x => x.Login == query.Login);*/

            return _mapper.MapObject(p);
        }
    }
}