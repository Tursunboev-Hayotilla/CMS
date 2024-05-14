using CMS.Domain.Entities.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Queries
{
    public class GetAllTeachersBySubjectQuery : IRequest<IEnumerable<Teacher>>
    {
        public Guid Id { get; set; }
    }
}
