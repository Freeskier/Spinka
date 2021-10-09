using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.EduBlocks.Queries.Handlers
{
    public class GetEduBlockIconsInfoQueryHandler : IQueryHandler<GetEduBlockIconsInfo, IconsInfoViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<EduBlock, IconsInfoViewModel> _mapper;

        public GetEduBlockIconsInfoQueryHandler(IUnitOfWork unitOfWork, IMapper<EduBlock, IconsInfoViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IconsInfoViewModel> HandleAsync(GetEduBlockIconsInfo query)
        {
            var info = await _unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == query.EduBlockId && !x.IsDeleted, i =>
                    i.Include(q => q.MedicalServiceForEduBlock)
                        .Include(q => q.AssignedTrainingFacilities)
                        .ThenInclude(q => q.TrainingFacility));
            return _mapper.MapObject(info);
        }
    }
}