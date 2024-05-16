using CMS.Domain.Entities.Enums;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Commands
{
    public class CreateLessonCommand:IRequest<ResponseModel>
    {
      //  public string Theme { get; set; }
        public Day Day { get; set; }
        public CustomeTime FromTime { get; set; }
        public CustomeTime ToTime { get; set;}
        public Guid? SubjectId { get; set; }
        public Guid? ClassId { get; set; }
        public string? TeacherId { get; set; }
    }
}