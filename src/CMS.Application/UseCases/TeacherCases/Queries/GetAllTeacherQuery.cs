using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Queries
{
    public class GetAllTeacherQuery : IRequest<IEnumerable<Teacher>>
    {
        public int PageIndex { get; set; }
        public int Count { get; set; }
    }
}
