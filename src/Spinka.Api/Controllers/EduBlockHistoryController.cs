using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.EduBlocksHistory.Queries;
using Spinka.Application.EduBlocksHistory.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EduBlockHistoryController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public EduBlockHistoryController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<IEnumerable<EduBlockHistoryViewModel>>> GetEduBlockHistoryByGuid(Guid guid)
        {
            var eduBlockHistoryList = await 
                _dispatcher.QueryAsync<GetEduBlockHistoryByGuid, IEnumerable<EduBlockHistoryViewModel>>(new GetEduBlockHistoryByGuid
                    {EduBlockHistoryGuid = guid});
            return new JsonResult(eduBlockHistoryList);
        }
    }
}