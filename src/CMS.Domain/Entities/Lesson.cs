using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Enums;

namespace CMS.Domain.Entities
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public required string Theme { get; set; }
        public required Day? Day { get; set; }
        public required TimeOnly? FromTime {  get; set; }
        public required TimeOnly? ToTime {  get; set; }
        public Guid?ClassId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? AttendanceId { get; set; }
        public string TeacherId { get; set; }

        // Virtualarni UseCaseslarda ishlatmatmaymiz
        public virtual Class Class { get; set; } 
        public virtual Subject Subject { get; set; }
        public virtual Attendance Attendance { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }

    }
}
