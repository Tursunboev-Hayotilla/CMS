using CMS.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities.Models
{
    public class StudentRegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Role {  get; set; }
        public string Password { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile PDF { get; set; }
        public Location Location { get; set; }
        public Guid ClassId { get; set; }
        public string PhoneNumber { get; set; }
        public string ParentsPhoneNumber { get; set; }
    }
}
