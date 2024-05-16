using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Queries
{
    public class GetHomeworkByLesson:IRequest<Homework>
    {
        public Guid LessonId { get; set; }
    }
}
