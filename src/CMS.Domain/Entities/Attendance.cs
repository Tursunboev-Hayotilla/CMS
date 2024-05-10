namespace CMS.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public object LessonId { get; set; }
        public object ClassId { get; set; }
    }
}
