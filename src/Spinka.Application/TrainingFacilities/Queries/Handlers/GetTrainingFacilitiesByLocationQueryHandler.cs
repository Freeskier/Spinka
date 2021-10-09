using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingFacilities.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingFacilities.Queries.Handlers
{
    public class GetTrainingFacilitiesByLocationQueryHandler : IQueryHandler<GetTrainingFacilitiesByLocation, IEnumerable<TrainingFacilityViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetTrainingFacilitiesByLocationQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<TrainingFacilityViewModel>> HandleAsync(GetTrainingFacilitiesByLocation query)
        {
            return await _mapper.ProjectTo<TrainingFacilityViewModel>(
                    _context.TrainingFacilities
                        .Where(x => x.Location == query.Location)
                        .AsNoTracking())
                .ToListAsync();
        }
    }
}