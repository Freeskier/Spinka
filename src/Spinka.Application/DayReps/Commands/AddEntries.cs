using Spinka.Application.Dispatchers.Commands;
using System.Collections.Generic;
using Spinka.Application.DayReps.ViewModels;

namespace Spinka.Application.DayReps.Commands
{
    public class AddEntries: ICommand
    {
        public List<DayRepSingleInputViewModel> DayRepListOfEntries { get; set; }

        public AddEntries()
        {
            DayRepListOfEntries = new List<DayRepSingleInputViewModel>();
        }
    }
}
