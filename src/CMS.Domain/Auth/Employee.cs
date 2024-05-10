using CMS.Domain.Entities;
using CMS.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Auth
{
    public class Employee:IdentityUser<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
