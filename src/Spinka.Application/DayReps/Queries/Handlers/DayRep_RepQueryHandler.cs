using Microsoft.EntityFrameworkCore;
using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinka.Application.DayReps.Queries.Handlers
{
    public class DayRep_RepQueryHandler: IQueryHandler<DayRep_RepQuery, List<DayRep_RepViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<DayRep_RepDBRequest, List<DayRep_RepViewModel>> _mapper;
        public DayRep_RepQueryHandler(IUnitOfWork unitOfWork,
            IMapper<DayRep_RepDBRequest, List<DayRep_RepViewModel>> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<DayRep_RepViewModel>> HandleAsync (DayRep_RepQuery query)
        {
            
            DayRep_RepDBRequest tmp =  new DayRep_RepDBRequest()
            {
                GroupID=query.GroupId,
                FullNameRenderingPersonId= query.FullNameRenderingPersonId,
                FullNameSigningPersonId= query.FullNameSigningPersonId,
                StartDate=query.StartDate,
                EndDate=query.EndDate

            };

            return _mapper.MapObject(tmp);
        }
    }
}
