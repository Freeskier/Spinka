using System.Collections.Generic;
using Spinka.Application.AssignedAmmo.Utils;
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.AssignedAmmo.Commands
{
    public class AssignedAmmoForEduBlock : ICommand
    {
        public IEnumerable<AssignedAmmoRequestModel> AssignedAmmo { get; set; }
    }
}