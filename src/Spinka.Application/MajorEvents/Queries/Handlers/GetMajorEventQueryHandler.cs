using System.Threading.Tasks;
using AutoMapper;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.MajorEvents.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.MajorEvents.Queries.Handlers
{
    public class GetMajorEventQueryHandler : IQueryHandler<GetMajorEvent, MajorEventViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<MajorEvent, MajorEventViewModel> _mapper;

        public GetMajorEventQueryHandler(IUnitOfWork unitOfWork, IMapper<MajorEvent, MajorEventViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MajorEventViewModel> HandleAsync(GetMajorEvent query)
        {
            var majorEvent = await _unitOfWork.Repository<MajorEvent>().FindByIdAsync(query.Id);
            return _mapper.MapObject(majorEvent);
        }
    }
}