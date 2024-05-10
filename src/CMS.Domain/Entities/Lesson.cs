using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Lesson
    {
        public Guid Id { get; set; } = new Guid();
        public required string Theme { get; set; }
        public virtual Subject SubjectId { get; set; }
        public required Day? Day { get; set; }
        public required TimeOnly? FromTime {  get; set; }
        public required TimeOnly? ToTime {  get; set; }
        public virtual Class ClassId { get; set; } 

    }
}
