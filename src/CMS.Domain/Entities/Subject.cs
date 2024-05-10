using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; } 
        public required string Name { get; set; }
    }
}
