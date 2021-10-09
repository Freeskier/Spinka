using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spinka.Application.Dispatchers;
using Spinka.Application.Vehicles.Queries;
using Spinka.Application.Vehicles.ViewModels;

namespace Spinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public VehicleController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleViewModel>>> GetAll()
        {
            var vehicles = await _dispatcher.QueryAsync<GetVehicles, IEnumerable<VehicleViewModel>>(new GetVehicles());
            
            return new JsonResult(vehicles);
        }
        
        [HttpGet("Ambulance")]
        public async Task<ActionResult<IEnumerable<VehicleViewModel>>> GetAllAmbulances()
        {
            var vehicles = await _dispatcher.QueryAsync<GetAmbulanceVehicles, IEnumerable<VehicleViewModel>>(new GetAmbulanceVehicles());
            
            return new JsonResult(vehicles);
        }
    }
}