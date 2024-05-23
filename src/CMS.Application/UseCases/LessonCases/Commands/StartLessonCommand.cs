using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Commands
{
    public class StartLessonCommand:IRequest<ResponseModel>
    {
        public Guid LessonId { get; set; }
        public string Theme { get; set; }
    }
}
