using CMS.Domain.Entities;
using CMS.Domain.Entities.Enums;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Commands
{
    public class UpdateStudentCommand:IRequest<ResponseModel>
    {
        public string Id {  get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public CustomeDate DateOfBirth { get; set; }
        public Location Location { get; set; }
        public string ParentsPhoneNumber { get; set; }
        public Guid? ClassId { get; set; }
        public IFormFile? Photo { get; set; }
        public IFormFile? PDF { get; set; }
    }
}
