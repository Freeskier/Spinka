using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Persons.Commands.Handlers
{
    public class CreatePersonCommandHandler : ICommandHandler<CreatePerson>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(CreatePerson command)
        {
            await _unitOfWork.Repository<Person>().GetOrFailWithCheckExistsAsync(x => x.Pesel == command.Pesel);

            var person = new Person
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Pesel = command.Pesel,
                Login = command.Login,
                OpNo = command.OpNo,
                PhoneNumber = command.PhoneNumber,
                MilitaryRankId = command.MilitaryRankId
            };

            await _unitOfWork.Repository<Person>().AddAsync(person);
            await _unitOfWork.Commit();
        }
    }
}