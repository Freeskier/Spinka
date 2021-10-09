using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.EduBlocks.Queries.Handlers
{
    public class GetEduBlocksWithMedicalServiceQueryHandler : IQueryHandler<GetEduBlocksWithMedicalService, IEnumerable<EduBlockViewModelForMedical>>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetEduBlocksWithMedicalServiceQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<EduBlockViewModelForMedical>> HandleAsync(GetEduBlocksWithMedicalService query)
        {
            return await _mapper.ProjectTo<EduBlockViewModelForMedical>(_context.EduBlocks
                    .Where(x => x.IsMedicalServiceRequired && !x.IsDeleted)
                    .Include(x => x.AssignedTrainingGroups)
                    .Include(x => x.EduBlockSubject))
                .ToListAsync();
        }
    }
}