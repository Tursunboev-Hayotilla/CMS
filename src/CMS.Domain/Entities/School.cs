using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class School
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required virtual Location LocationId { get; set; }
        public int? ClassCount { get; set; }
        public int? StudentCount { get; set; }
        public string? PhotoPath { get; set; }
        public string? EmployeesCount { get; set; }
    }
}
