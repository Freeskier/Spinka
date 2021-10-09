using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingFacilities.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.TrainingFacilities.Queries.Handlers
{
    public class GetTrainingFacilitiesQueryHandler : IQueryHandler<GetTrainingFacilities, IEnumerable<TrainingFacilityViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetTrainingFacilitiesQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<TrainingFacilityViewModel>> HandleAsync(GetTrainingFacilities query)
        {
            return await _mapper.ProjectTo<TrainingFacilityViewModel>(
                    _context.TrainingFacilities
                        .AsNoTracking())
                .ToListAsync();
        }
    }
}