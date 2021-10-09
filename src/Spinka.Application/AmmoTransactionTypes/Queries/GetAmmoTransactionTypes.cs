using System.Collections.Generic;
using Spinka.Application.AmmoTransactionTypes.ViewModels;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.AmmoTransactionTypes.Queries
{
    public class GetAmmoTransactionTypes : IQuery<IEnumerable<AmmoTransactionTypeViewModel>> { }
}