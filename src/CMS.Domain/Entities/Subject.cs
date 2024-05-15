using System;
using System.Collections.Generic;

namespace CMS.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}