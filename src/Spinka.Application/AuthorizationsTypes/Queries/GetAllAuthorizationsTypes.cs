using System.Collections.Generic;
using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.AuthorizationsTypes.Queries
{
    public class GetAllAuthorizationsTypes : IQuery<IEnumerable<AuthorizationsTypeViewModel>>
    {
    }
}