using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public object LessonId { get; set; }
        public object ClassId { get; set; }
    }
}
