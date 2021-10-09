using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using Spinka.Application.GroupForDayReps.ViewModels;

namespace Spinka.Application.GroupForDayReps.Mappers
{
    public class GetAllGroupsMapper : IMapper<GroupForDayRep, GetAllGroupsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGroupsMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetAllGroupsViewModel MapObject(GroupForDayRep entity)
        {
            return new GetAllGroupsViewModel
            {
                GroupId = entity.Id,
                GroupName = entity.Name
            };
        }
    }
}

