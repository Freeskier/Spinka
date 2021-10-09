using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.EduBlocks.Queries.Handlers
{
    public class GetMajorEventAssignedToEduBlockQueryHandler : IQueryHandler<GetMajorEventAssignedToEduBlock, MajorEventAssignedToEduBlockViewModel>
    {
        private readonly SpinkaContext _context;
        private readonly IMapper _mapper;

        public GetMajorEventAssignedToEduBlockQueryHandler(SpinkaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MajorEventAssignedToEduBlockViewModel> HandleAsync(GetMajorEventAssignedToEduBlock query)
        {
            return await _mapper.ProjectTo<MajorEventAssignedToEduBlockViewModel>(_context.EduBlocks
                .Where(x => !x.IsDeleted && x.Id == query.EduBlockId)
                .Include(x => x.MajorEvent)).FirstOrDefaultAsync();
        }
    }
}