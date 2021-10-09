using System;

namespace Spinka.Domain.Models
{
    public class EduBlockControl : BaseEntity
    {
        public virtual EduBlock EduBlock { get; set; }
        public int EduBlockId { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        public bool Attended { get; set; }
        public string AbsenceReason { get; set; }
        public string AdminLogin { get; set; }
        public DateTime LastTimeModified { get; set; }
        public string Remarks { get; set; }
        public int Grade { get; set; }
    }
}