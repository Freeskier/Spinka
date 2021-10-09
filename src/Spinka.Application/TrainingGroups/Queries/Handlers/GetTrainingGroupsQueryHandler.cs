using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;
using TrainingGroupEntity =  Spinka.Domain.Models.TrainingGroup;

namespace Spinka.Application.TrainingGroups.Queries.Handlers
{
    public class GetTrainingGroupsQueryHandler : IQueryHandler<GetTrainingGroups, IEnumerable<TrainingGroupViewModel>>
    {
        private readonly IMapper  _mapper;
        private readonly SpinkaContext _context;

        public GetTrainingGroupsQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<TrainingGroupViewModel>> HandleAsync(GetTrainingGroups query)
        {
            return await _mapper.ProjectTo<TrainingGroupViewModel>(
                    _context.TrainingGroups
                    .Include(x => x.TrainingGroupsPersons)
                    .AsNoTracking())
                .ToListAsync();
        }
    }
}