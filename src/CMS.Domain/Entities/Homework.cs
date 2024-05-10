using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Homework
    {
        public Guid Id { get; set; } = new Guid();
        public virtual Lesson LessonId { get; set; }
        public string Result { get; set; }
        public int Coin { get; set; }
        public required DateTimeOffset StartDate { get; set; }
        public required DateTimeOffset EndDate { get; set;}

    }
}
