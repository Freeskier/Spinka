using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlockSubjects.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.EduBlockSubjects.Queries.Handlers
{
    public class GetEduBlockSubjectsQueryHandler : IQueryHandler<GetEduBlockSubjects, IEnumerable<EduBlockSubjectViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetEduBlockSubjectsQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<EduBlockSubjectViewModel>> HandleAsync(GetEduBlockSubjects query)
        {
            return await _mapper.ProjectTo<EduBlockSubjectViewModel>(
                _context.EduBlockSubjects)
                .ToListAsync();
        }
    }
}