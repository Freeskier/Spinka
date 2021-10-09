using System;
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.TrainingGroupsPerson.Commands
{
    public class DeletePersonFromGroup : ICommand
    {
        public int Id { get; set; }
    }
}