using System.Collections.Generic;
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.DayReps.Commands
{
    public class DeleteDayRepEntry: ICommand
    {
        public List<int> ListDayRepsId { get; set; }

        public DeleteDayRepEntry()
        {
            ListDayRepsId = new List<int>();
        }
    }
}
