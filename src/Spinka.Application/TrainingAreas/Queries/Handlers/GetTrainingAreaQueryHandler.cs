using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingAreas.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.TrainingAreas.Queries.Handlers
{
    public class GetTrainingAreaQueryHandler : IQueryHandler<GetTrainingArea, TrainingAreaDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly SpinkaContext _context;

        public GetTrainingAreaQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<TrainingAreaDetailViewModel> HandleAsync(GetTrainingArea query)
        {
            return await _mapper.ProjectTo<TrainingAreaDetailViewModel>(
                    _context.TrainingAreas
                    .Where(x => x.Id == query.Id)
                    .Include(x => x.EduBlockSubjects)
                    .AsNoTracking())
                .SingleOrDefaultAsync();
        }
    }
}