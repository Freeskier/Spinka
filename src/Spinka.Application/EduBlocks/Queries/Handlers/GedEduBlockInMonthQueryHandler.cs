using System.Collections;
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
    public class GedEduBlockInMonthQueryHandler : IQueryHandler<GetEduBlocksInMonth, IEnumerable<EduBlockToApproveViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GedEduBlockInMonthQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<EduBlockToApproveViewModel>> HandleAsync(GetEduBlocksInMonth query)
        {
            return await _mapper.ProjectTo<EduBlockToApproveViewModel>(_context.EduBlocks
                    .Where(x => !x.IsDeleted && x.StartTime.Month == query.MonthNumber)
                    .Include(x => x.AssignedTrainingGroups)
                    .Include(x => x.EduBlockSubject))
                .ToListAsync();
        }
    }
}