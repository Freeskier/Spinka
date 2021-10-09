using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.Persons.Commands
{
    public class CreatePerson : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Login { get; set; }
        public int OpNo { get; set; }
        public string PhoneNumber { get; set; }
        public int? MilitaryRankId { get; set; }

        public CreatePerson() { }
        
        public CreatePerson(string firstName, string lastName, string pesel, string login,
            string phoneNumber, int opNo = 0, int? militaryRankId = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Login = login;
            OpNo = opNo;
            PhoneNumber = phoneNumber;
            MilitaryRankId = militaryRankId;
        }
    }
}