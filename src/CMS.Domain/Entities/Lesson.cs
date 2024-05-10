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
        public object subjectId { get; set; }
        public required Day? day { get; set; }
        public required TimeOnly? fromTime {  get; set; }
        public required TimeOnly? toTime {  get; set; }
        public object classId { get; set; } 

    }
}
