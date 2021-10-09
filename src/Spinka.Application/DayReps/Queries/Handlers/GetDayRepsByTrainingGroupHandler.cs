using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.DayReps.Queries.Handlers
{
    public class GetDayRepsByTrainingGroupHandler : IQueryHandler<GetDayRepsByTrainingGroup, IEnumerable<GetDayRepsByTrainingGroupViewModel>>
    {
        public GetDayRepsByTrainingGroupHandler(IUnitOfWork unitOfWork, IMapper<DayRep, GetDayRepsByTrainingGroupViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<DayRep, GetDayRepsByTrainingGroupViewModel> _mapper;

        public GetDayRepsByTrainingGroupHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetDayRepsByTrainingGroupViewModel>> HandleAsync(GetDayRepsByTrainingGroup query)
        {
            var dayReps = await _unitOfWork.Repository<Domain.Models.TrainingGroupsPerson>()
                .FindAllWithIncludesAsync(x => x.TrainingGroupId == query.TrainingGroupId && !x.IsDeleted,
                    i =>
                        i.Include(q => q.Person)
                            .ThenInclude(q => q.DayRepGroupPersons)
                            .ThenInclude(q => q.DayReps)
                            .ThenInclude(q => q.DayRepAcronym)
                            .Include(q => q.Person.MilitaryRank))
                .SelectAsync(y => y.SelectMany(z => z.Person.DayRepGroupPersons.SelectMany(q => q.DayReps)).Where(t => t.Day == query.Day));

            return dayReps.Select(_mapper.MapObject);

        }
    }
}