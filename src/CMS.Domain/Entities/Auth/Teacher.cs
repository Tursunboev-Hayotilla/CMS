using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Enums;
using CMS.Domain.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace CMS.Domain.Entities.Auth
{
    public class Teacher : User
    {
        public Gender Gender { get; set; }
        public string? PhotoPath { get; set; }
        public virtual CustomeDate BirthDate { get; set; }
        public string? PDFPath { get; set; }
        public Guid? SubjectId { get; set; }
     
        public virtual Subject Subject { get; set; }
        public virtual  Location Location { get; set; }

    }
}
