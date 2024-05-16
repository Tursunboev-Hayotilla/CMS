using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Enums;
using CMS.Domain.Entities.Models;

namespace CMS.Domain.Entities
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Theme { get; set; }
        public Day? Day { get; set; }
        public virtual CustomeTime? FromTime { get; set; }
        public virtual CustomeTime? ToTime { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? AttendanceId { get; set; }
        public string TeacherId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<StudentAttendance> StudentAttendances { get; set; }
        public virtual Attendance Attendance { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
