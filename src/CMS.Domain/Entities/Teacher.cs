using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; } = new Guid();
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public Gender? gender { get; set; } 
        public string? photoPath { get; set; }
        public required string email { get; set; }
        public required string phoneNumber { get; set; }
        public object subjectId { get; set; }
        public required object location { get; set; }
    }
}
