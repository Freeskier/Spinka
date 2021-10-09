using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingAreas.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingAreas.Queries.Handlers
{
    public class GetTrainingAreasQueryHandler : IQueryHandler<GetTrainingAreas, IEnumerable<TrainingAreaViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetTrainingAreasQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<TrainingAreaViewModel>> HandleAsync(GetTrainingAreas query)
        {
            return await _mapper.ProjectTo<TrainingAreaViewModel>(
                    _context.TrainingAreas
                        .AsNoTracking())
                .ToListAsync();
        }
    }
}