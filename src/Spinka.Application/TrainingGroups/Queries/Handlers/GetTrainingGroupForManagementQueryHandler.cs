using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Infrastructure.Database;

namespace Spinka.Application.TrainingGroups.Queries.Handlers
{
    public class GetTrainingGroupForManagementQueryHandler : IQueryHandler<GetTrainingGroupForManagement, TrainingGroupForManagementViewModel>
    {
        private readonly SpinkaContext _context;
        private readonly IMapper _mapper;

        public GetTrainingGroupForManagementQueryHandler(IMapper mapper, SpinkaContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<TrainingGroupForManagementViewModel> HandleAsync(GetTrainingGroupForManagement query)
        {
            var result = _context.TrainingGroups
                .Where(x => x.Id == query.GroupId)
                .Include(x => x.TrainingGroupsPersons)
                .ThenInclude(x => x.Person)
                .ThenInclude(x => x.MilitaryRank)
                .AsNoTracking();
            
            // REFACTOR TO DAPPER!!!
            var trainings = await _mapper.ProjectTo<TrainingGroupForManagementViewModel>(
                result)
                .SingleOrDefaultAsync();

            var groups = _context.TrainingGroupsPersons
                .Include(i => i.Person.PersonInTrainingGroups)
                .ThenInclude(i => i.TrainingGroup);
            
            foreach (var person in trainings.ListOfPersonnelForGroups)
            {
                var p = _context.TrainingGroupsPersons
                    .Include(x => x.Person)
                    .First(x => x.Id == person.PersonInGroupId);
                
                var g = groups.Where(x => 
                   x.PersonId == p.PersonId && x.TrainingGroupId != query.GroupId);
            
                StringBuilder builder = new StringBuilder();
                
                foreach (var group in g)
                {
                    builder.Append(group.TrainingGroup.Name + ", ");
                }

                person.OtherGroupStatus = builder.ToString();
            }
            return trainings;
        }
    }
}