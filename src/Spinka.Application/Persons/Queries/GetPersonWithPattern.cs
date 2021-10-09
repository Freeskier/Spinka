using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Persons.ViewModels;

namespace Spinka.Application.Persons.Queries
{
    public class GetPersonWithPattern : IQuery<IEnumerable<PersonViewModel>>
    {
        public string Pattern { get; set; }
        public IEnumerable<int> Ids { get; set; }
    }
}