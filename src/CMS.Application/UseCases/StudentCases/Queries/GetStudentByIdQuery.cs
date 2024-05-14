using CMS.Domain.Entities.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Queries
{
    public class GetStudentByIdQuery:IRequest<Student>
    {
        public string Id { get; set; }
    }
}
