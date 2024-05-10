namespace CMS.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public virtual Lesson LessonId { get; set; }
        public virtual Class ClassId { get; set; }
    }
}
