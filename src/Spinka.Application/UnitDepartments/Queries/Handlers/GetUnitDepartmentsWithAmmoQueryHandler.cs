using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.UnitDepartments.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.UnitDepartments.Queries.Handlers
{
    public class GetUnitDepartmentsWithAmmoQueryHandler : IQueryHandler<GetUnitDepartmentsWithAmmo, IEnumerable<UnitDepartmentWithAmmoDetailViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetUnitDepartmentsWithAmmoQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<UnitDepartmentWithAmmoDetailViewModel>> HandleAsync(GetUnitDepartmentsWithAmmo query)
        {
            return await _mapper.ProjectTo<UnitDepartmentWithAmmoDetailViewModel>(
                    _context.UnitDepartments
                        .Include(x => x.CurrentAmmoLimitsForDepartments)
                        .AsNoTracking())
                .ToListAsync();
        }
    }
}