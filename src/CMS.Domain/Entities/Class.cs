namespace CMS.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public object TeacherId { get; set; }
        public object StudentList { get; set; }
        public object SubjectList { get; set; }
        public object AttendanceList { get; set; }
        public byte Grade { get; set; }
    }
}
