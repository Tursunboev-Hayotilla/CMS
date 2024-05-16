using CMS.Domain.Entities.Auth;

namespace CMS.Domain.Entities.Models
{
    public class StudentAttendance
    {
        public Guid Id { get; set; }
        public string StudentId { get; set; }
        public Guid LessonId { get; set; }
        public bool IsPresent { get; set; }
        public virtual Student Student { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
