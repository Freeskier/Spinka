using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.AmmoTransactionTypes.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.AmmoTransactionTypes.Queries.Handlers
{
    public class GetAmmoTransactionTypesQueryHandler : IQueryHandler<GetAmmoTransactionTypes, IEnumerable<AmmoTransactionTypeViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetAmmoTransactionTypesQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<AmmoTransactionTypeViewModel>> HandleAsync(GetAmmoTransactionTypes query)
        {
            return await _mapper.ProjectTo<AmmoTransactionTypeViewModel>(
                    _context.AmmoTransactionTypes)
                .ToListAsync();
        }
    }
}