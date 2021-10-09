using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.TrainingGroups.Queries;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Application.UnitDepartments.Queries;
using Spinka.Application.UnitDepartments.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitDepartmentController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public UnitDepartmentController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitDepartmentViewModel>>> GetAll()
        {
            var unitDepartments = await _dispatcher.QueryAsync<GetUnitDepartments, IEnumerable<UnitDepartmentViewModel>>(new GetUnitDepartments());
            
            return new JsonResult(unitDepartments);
        }
        
        [HttpGet("Ammo")]
        public async Task<ActionResult<IEnumerable<UnitDepartmentWithAmmoDetailViewModel>>> GetWithAmmo()
        {
            var unitDepartments = await _dispatcher.QueryAsync<GetUnitDepartmentsWithAmmo, IEnumerable<UnitDepartmentWithAmmoDetailViewModel>>(new GetUnitDepartmentsWithAmmo());
            
            return new JsonResult(unitDepartments);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitDepartmentDetailViewModel>> GetDetail(int id)
        {
            var unitDepartment = await _dispatcher.QueryAsync<GetUnitDepartment, UnitDepartmentDetailViewModel>(new GetUnitDepartment
                {
                    Id = id
                });
                
            return new JsonResult(unitDepartment);
        }
        
        [HttpGet("{id}/TrainingGroups")]

        public async Task<ActionResult<IEnumerable<TrainingGroupsInDepartmentViewModel>>>
            GetTrainingGroupsInDepartment(int id)
        {
            var trainingGroupsViewModel = await 
                _dispatcher.QueryAsync<GetTrainingGroupsInDepartment, IEnumerable<TrainingGroupsInDepartmentViewModel>>(
                    new GetTrainingGroupsInDepartment {DepartmentId = id});
            return new JsonResult(trainingGroupsViewModel);
        }
    }
}