using Spinka.Application.Persons.ViewModels;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.Persons.Mappers
{
    public class PersonByLoginMapper : IMapper<Person, PersonByLoginViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonByLoginMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public PersonByLoginViewModel MapObject(Person entity)
        {
            return new PersonByLoginViewModel
            {
                Id = entity.Id,
                Login = entity.Login,
                FullName = MapperHelper.HelpWithGetPersonFullName(entity.Id, _unitOfWork)
            };
        }
    }
}