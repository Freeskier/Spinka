using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.GroupForDayReps.Queries.Handlers
{
    public class GetAllGroupsHandler : IQueryHandler<GetAllGroupsQuery, IEnumerable<GetAllGroupsViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;
        
        public GetAllGroupsHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<GetAllGroupsViewModel>> HandleAsync(GetAllGroupsQuery query)
        {
             return await _mapper.ProjectTo<GetAllGroupsViewModel>(
                     _context.GroupForDayReps
                         .Where(x => !x.IsDeleted))
                 .ToListAsync();
        }
    }
}
