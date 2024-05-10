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
        // Shuni nma qilishini chunmadim to'grisi
        public string Result { get; set; }
        public int Coin { get; set; }
        public required DateTimeOffset StartDate { get; set; }
        public required DateTimeOffset EndDate { get; set;}
        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

    }
}
