using CMS.Domain.Entities.Models;

namespace CMS.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public Guid StudentAttendanceId { get; set; }
        public virtual CustomeDate Date { get; set; }
        public virtual StudentAttendance StudentAttendance { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}

