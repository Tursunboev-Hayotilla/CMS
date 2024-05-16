using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities.Models
{
    public class StudentAppraciate
    {
        public Guid Id { get; set; }
        public string studentId { get; set; }
        public Guid LessonId { get; set; }
        public byte? LessonCoin { get; set; }
        public byte? HomeworkCoin { get; set; }
    }
}
