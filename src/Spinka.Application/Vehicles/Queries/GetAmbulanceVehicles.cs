using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Vehicles.ViewModels;

namespace Spinka.Application.Vehicles.Queries
{
    public class GetAmbulanceVehicles : IQuery<IEnumerable<VehicleViewModel>> { }
}