using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Persons.ViewModels;

namespace Spinka.Application.Persons.Queries
{
    public class GetPersonsWithoutCivilians : IQuery<IEnumerable<PersonViewModel>> { }
}