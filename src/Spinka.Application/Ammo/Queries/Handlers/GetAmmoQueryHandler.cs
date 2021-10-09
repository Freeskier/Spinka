using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Ammo.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;
using AmmoEntity = Spinka.Domain.Models.Ammo;

namespace Spinka.Application.Ammo.Queries.Handlers
{
    public class GetAmmoQueryHandler : IQueryHandler<GetAmmo, IEnumerable<AmmoViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetAmmoQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<AmmoViewModel>> HandleAsync(GetAmmo query)
        {
            return await _mapper.ProjectTo<AmmoViewModel>(_context.Ammo
                    .Include(x => x.AmmoType)
                    .Include(x => x.MeasureUnit))
                .ToListAsync();
        }
    }
}