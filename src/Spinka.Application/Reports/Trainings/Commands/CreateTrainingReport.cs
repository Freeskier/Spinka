using System;
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.Reports.Trainings.Commands
{
    public class CreateTrainingReport : ICommand
    {
        public DateTime StartTime { get; set; }
        public DateTime EndOn { get; set; }
    }
}