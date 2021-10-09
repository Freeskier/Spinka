using System;
using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class MajorEvent : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime EndOn { get; set; }
        public string AdditionalInformation { get; set; } 
        public virtual UnitDepartment UnitDepartment { get; set; }
        public int UnitDepartmentId { get; set; }
        public virtual EventType EventType { get; set; }
        public int EventTypeId { get; set; }
        private ISet<EduBlock> _eduBlocks = new HashSet<EduBlock>();
        public IEnumerable<EduBlock> EduBlocks => _eduBlocks;
    }
}