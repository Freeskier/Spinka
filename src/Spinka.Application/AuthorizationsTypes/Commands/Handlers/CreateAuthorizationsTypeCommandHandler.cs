using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.AuthorizationsTypes.Commands.Handlers
{
    public class CreateAuthorizationsTypeCommandHandler : ICommandHandler<CreateAuthorizationsType>
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorizationsTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(CreateAuthorizationsType command)
        {
            var authorizationsType = await _unitOfWork.Repository<AuthorizationsType>().GetOrFailWithCheckExistsAsync(x => x.Name == command.AuthorizationsTypeName);
            if (authorizationsType != null)
            {
                authorizationsType.IsDeleted = false;
                await _unitOfWork.Repository<AuthorizationsType>().EditAsync(authorizationsType);
            }
            else
            {
                authorizationsType = new AuthorizationsType
                {
                    Name = command.AuthorizationsTypeName,
                    IsDeleted = false,
                };
                await _unitOfWork.Repository<AuthorizationsType>().AddAsync(authorizationsType);
            }
            
            
            await _unitOfWork.Commit();
        }
    }
}