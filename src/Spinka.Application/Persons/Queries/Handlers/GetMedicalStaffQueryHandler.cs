using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Persons.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.Persons.Queries.Handlers
{
    public class GetMedicalStaffQueryHandler : IQueryHandler<GetMedicalStaff, IEnumerable<PersonViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;
        
        public GetMedicalStaffQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<PersonViewModel>> HandleAsync(GetMedicalStaff query)
        {
            return await _mapper.ProjectTo<PersonViewModel>(_context.Persons
                    .Include(x => x.MilitaryRank)
                    .Include(x => x.PersonAuthorisedForEduBlockFunctions)
                    .Where(x => x.PersonAuthorisedForEduBlockFunctions
                        .Any(p => p.AuthorisationsTypeId == 10 || p.AuthorisationsTypeId == 11))
                    .AsNoTracking())
                .ToListAsync();
        }
    }
}