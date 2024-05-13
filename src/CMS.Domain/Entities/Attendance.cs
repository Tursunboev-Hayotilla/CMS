using CMS.Domain.Entities.Models;

namespace CMS.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid ClassId { get; set; }
        public virtual  CustomeDate  Date { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Class Class{ get; set; }
    }
}
