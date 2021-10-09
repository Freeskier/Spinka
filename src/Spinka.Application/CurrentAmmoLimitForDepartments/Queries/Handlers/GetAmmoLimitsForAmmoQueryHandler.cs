using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;
using AmmoEntity = Spinka.Domain.Models.Ammo;

namespace Spinka.Application.CurrentAmmoLimitForDepartments.Queries.Handlers
{
    public class GetAmmoLimitsForAmmoQueryHandler : IQueryHandler<GetAmmoLimitsForAmmo, IEnumerable<LimitForAmmoViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetAmmoLimitsForAmmoQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<LimitForAmmoViewModel>> HandleAsync(GetAmmoLimitsForAmmo query)
        {
            return await _mapper.ProjectTo<LimitForAmmoViewModel>(_context.CurrentAmmoLimitsForDepartments
                    .Where(x => x.AmmoId == query.AmmoId)
                    .Include(x => x.Ammo)
                    .ThenInclude(x => x.MeasureUnit)
                    .Include(x => x.UnitDepartment))
                .ToListAsync();
        }
    }
}