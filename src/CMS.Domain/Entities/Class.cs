using CMS.Domain.Auth;

namespace CMS.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required byte Grade { get; set; }
        public Guid TeacherId { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Attendance> Attendances { get; set; }

        // Virtualarni UseCaseslarda ishlatmatmaymiz
        public virtual Teacher Teacher{ get; set; }
    }
}
