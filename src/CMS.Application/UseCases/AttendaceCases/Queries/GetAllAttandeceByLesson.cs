using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.AttendaceCases.Queries
{
    public class GetAllAttandeceByLesson:IRequest<IEnumerable<Attendance>>
    {
        public Guid lessonId { get; set; }
    }
}
