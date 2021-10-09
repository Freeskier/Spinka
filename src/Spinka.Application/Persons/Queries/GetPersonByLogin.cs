using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Persons.ViewModels;

namespace Spinka.Application.Persons.Queries
{
    public class GetPersonByLogin : IQuery<PersonByLoginViewModel>
    {
        public string Login { get; set; }
    }
}