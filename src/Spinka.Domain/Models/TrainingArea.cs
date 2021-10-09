using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class TrainingArea : BaseEntity
    {
        public string Name { get; set; }
        public string TrainingAcronym { get; set; }

        private ISet<EduBlockSubject> _eduBlockSubjects = new HashSet<EduBlockSubject>();
        public IEnumerable<EduBlockSubject> EduBlockSubjects => _eduBlockSubjects;
    }
}