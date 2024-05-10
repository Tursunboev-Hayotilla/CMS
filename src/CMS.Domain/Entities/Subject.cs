using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; } = new Guid();
        public required string Name { get; set; }
    }
}
