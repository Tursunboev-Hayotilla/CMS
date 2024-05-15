using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Commands
{
    public class DeleteLessonCommand:IRequest<ResponseModel>
    {
        public Guid lessonId { get; set; }
    }
}
