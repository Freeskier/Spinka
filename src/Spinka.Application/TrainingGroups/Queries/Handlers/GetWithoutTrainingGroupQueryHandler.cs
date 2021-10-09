using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingGroups.Queries.Handlers
{
    public class GetWithoutTrainingGroupQueryHandler : IQueryHandler<GetWithoutTrainingGroup, IEnumerable<TrainingGroupViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetWithoutTrainingGroupQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<TrainingGroupViewModel>> HandleAsync(GetWithoutTrainingGroup query)
        {
            return await _mapper.ProjectTo<TrainingGroupViewModel>(
                    _context.TrainingGroups
                        .Where(x => x.Id != query.Id)
                        .AsNoTracking())
                .ToListAsync();
        }
    }
}