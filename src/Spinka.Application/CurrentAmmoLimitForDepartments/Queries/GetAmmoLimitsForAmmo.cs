using System.Collections.Generic;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.CurrentAmmoLimitForDepartments.Queries
{
    public class GetAmmoLimitsForAmmo : IQuery<IEnumerable<LimitForAmmoViewModel>>
    {
        public int AmmoId { get; set; }
    }
}