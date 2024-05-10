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
        public required string Description { get; set; }
        public string? PhotoPath { get; set; }
        public Guid SchoolId { get; set; }

        // Virtualarni UseCaseslarda ishlatmatmaymiz
        public virtual School School { get; set; }
    }
}