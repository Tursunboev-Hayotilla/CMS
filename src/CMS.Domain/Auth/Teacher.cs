using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace CMS.Domain.Auth
{
    public class Teacher : IdentityUser<Guid>
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public Gender Gender { get; set; }
        public string? PhotoPath { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? SubjectId {  get; set; } 
        public virtual Subject Subject { get; set; }
        public virtual Location Location { get; set; }
    }
}
