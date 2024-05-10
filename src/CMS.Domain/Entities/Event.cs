using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required DateTimeOffset Date { get; set; }
        public virtual School SchoolId { get; set; }
        public string? Description { get; set; }
        public string? PhotoPath { get; set; }
    }
}
