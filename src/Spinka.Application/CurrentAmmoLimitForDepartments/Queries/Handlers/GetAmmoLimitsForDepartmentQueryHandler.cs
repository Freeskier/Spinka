using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.CurrentAmmoLimitForDepartments.Queries.Handlers
{
    public class GetAmmoLimitsForDepartmentQueryHandler : IQueryHandler<GetAmmoLimitsForDepartment, IEnumerable<LimitForDepartmentViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetAmmoLimitsForDepartmentQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<LimitForDepartmentViewModel>> HandleAsync(GetAmmoLimitsForDepartment query)
        {
            return await _mapper.ProjectTo<LimitForDepartmentViewModel>(_context.CurrentAmmoLimitsForDepartments
                .Where(x => x.UnitDepartmentsId == query.UnitDepartmentId)
                .Include(x => x.Ammo)
                .ThenInclude(x => x.MeasureUnit)
            ).ToListAsync();
        }
    }
}