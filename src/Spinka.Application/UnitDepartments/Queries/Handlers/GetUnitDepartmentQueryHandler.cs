using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.UnitDepartments.ViewModels;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.UnitDepartments.Queries.Handlers
{
    public class GetUnitDepartmentQueryHandler : IQueryHandler<GetUnitDepartment, UnitDepartmentDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;
        
        public GetUnitDepartmentQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<UnitDepartmentDetailViewModel> HandleAsync(GetUnitDepartment query)
        {
            return await _mapper.ProjectTo<UnitDepartmentDetailViewModel>(
                _context.UnitDepartments
                    .Where(x => x.Id == query.Id)
                    .Include(x => x.CurrentAmmoLimitsForDepartments)
                    .AsNoTracking())
                    .SingleOrDefaultAsync();
        }
    }
}