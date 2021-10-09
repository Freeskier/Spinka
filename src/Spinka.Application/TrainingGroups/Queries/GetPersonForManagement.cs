using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingGroups.ViewModels;

namespace Spinka.Application.TrainingGroups.Queries
{
    public class GetPersonForManagement : IQuery<IEnumerable<PersonForManagementViewModel>>
    {
        public int GroupId { get; set; }
    }
}