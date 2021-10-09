using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Spinka.Application.TrainingGroups.ViewModels
{
    public class PersonForGroupViewModel
    {
        public int PersonInGroupId { get; set; }
        public string FullName { get; set; }
        public int NoOp { get; set; }
        public string OtherGroupStatus { get; set; }
    }
}