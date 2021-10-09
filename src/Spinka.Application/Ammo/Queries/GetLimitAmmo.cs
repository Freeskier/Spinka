using System.Collections.Generic;
using Spinka.Application.Ammo.ViewModels;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.Ammo.Queries
{
    public class GetLimitAmmo : IQuery<IEnumerable<AmmoDetailViewModel>>
    {
        public int GroupId { get; set; }
    }
}