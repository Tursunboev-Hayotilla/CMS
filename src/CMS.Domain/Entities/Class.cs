namespace CMS.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public virtual Teacher TeacherId { get; set; }
        public Student StudentList { get; set; }
        public Subject SubjectList { get; set; }
        public Attendance AttendanceList { get; set; }
        public required byte Grade { get; set; }
    }
}
