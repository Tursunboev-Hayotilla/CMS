using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace CMS.Domain.Entities.Auth
{
    public class Student : User
    {
        public Gender? Gender { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int Coin { get; set; } = 0;
        public string ParentsPhoneNumber { get; set; }
        public Guid? ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Location Location { get; set; }
        public string? PhotoPath { get; set; }
        public string? PDFPath { get; set; }
        public string Role { get; set; } = "Student";

       
    }
}
