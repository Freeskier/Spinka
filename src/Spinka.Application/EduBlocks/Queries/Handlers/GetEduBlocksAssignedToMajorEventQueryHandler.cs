using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.EduBlocks.Queries.Handlers
{
    public class GetEduBlocksAssignedToMajorEventQueryHandler : IQueryHandler<GetEduBlocksAssignedToMajorEvent, IEnumerable<EduBlockViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetEduBlocksAssignedToMajorEventQueryHandler(SpinkaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<EduBlockViewModel>> HandleAsync(GetEduBlocksAssignedToMajorEvent query)
        {
            return await _mapper.ProjectTo<EduBlockViewModel>(_context.EduBlocks
                    .Where(x => !x.IsDeleted && x.MajorEventId == query.MajorEventId)
                    .Include(x => x.AssignedTrainingGroups)
                    .Include(x => x.EduBlockSubject))
                .ToListAsync();
        }
    }
}