using CMS.Domain.Entities.Enums;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CMS.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;

namespace CMS.Application.UseCases.TeacherCases.Commands
{
    public class UpdateTeacherCommand : IRequest<ResponseModel>
    {
        public string Id { get; set; } 

        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public Gender Gender { get; set; }
        public IFormFile? Photo { get; set; }
        public IFormFile? PDF {  get; set; }
        public  string PhoneNumber { get; set; }
        public Guid? SubjectId { get; set; }
        public Location Location { get; set; }
    }
}
