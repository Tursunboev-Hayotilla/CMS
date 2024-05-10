using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string? PhotoPath { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public Class ClassId { get; set; }
        public int Coin { get; set; }
        public required string Location { get; set; }
    }
}
