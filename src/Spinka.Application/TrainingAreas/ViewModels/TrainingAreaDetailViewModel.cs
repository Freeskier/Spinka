using System.Collections.Generic;

namespace Spinka.Application.TrainingAreas.ViewModels
{
    public class TrainingAreaDetailViewModel : TrainingAreaViewModel
    {
        public IEnumerable<EduBlockSubjectForTrainingAreaViewModel> EduBlockSubjects { get; set; }
    }
}