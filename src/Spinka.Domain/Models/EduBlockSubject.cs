using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class EduBlockSubject : BaseEntity
    {
        public string Subject { get; set; }
        public bool IsCountedIn { get; set; }
        public int? TypeOfRequirement { get; set; }

        private ISet<EduBlock> _eduBlocks = new HashSet<EduBlock>();
        public IEnumerable<EduBlock> EduBlocks => _eduBlocks;

        public virtual TrainingArea TrainingArea { get; set; }
        public int? TrainingAreaId { get; set; }
    }
}