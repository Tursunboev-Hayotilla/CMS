using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Queries
{
    public class GetAllLessonQuery:IRequest<IEnumerable<Lesson>>
    {
    }
}
