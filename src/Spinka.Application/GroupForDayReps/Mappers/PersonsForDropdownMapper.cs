using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Application.Utils.Helpers;

namespace Spinka.Application.GroupForDayReps.Mappers
{
    public class PersonsForDropdownMapper : IMapper<Person, PersonsForDropdownViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonsForDropdownMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PersonsForDropdownViewModel MapObject(Person entity)
        {
            var model = new PersonsForDropdownViewModel()
            {
                PersonId = entity.Id,
                PersonFullData= MapperHelper.HelpWithGetPersonFullName(entity.Id, _unitOfWork)
            };

            return model;
        }
    }
}
