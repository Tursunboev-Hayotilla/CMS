using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Homework
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public string? TaskPath  { get; set; }
        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

    }
}
