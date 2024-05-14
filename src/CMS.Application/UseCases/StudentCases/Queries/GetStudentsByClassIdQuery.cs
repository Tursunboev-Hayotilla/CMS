using CMS.Domain.Entities.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Queries
{
    public class GetStudentsByClassIdQuery:IRequest<IEnumerable<Student>>
    {
        public Guid Id { get; set; }
    }
}
