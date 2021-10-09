using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Persons.ViewModels;

namespace Spinka.Application.Persons.Queries
{
    public class GetMedicalStaff : IQuery<IEnumerable<PersonViewModel>> { }
}