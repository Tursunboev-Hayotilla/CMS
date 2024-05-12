using CMS.Domain.Entities;
using CMS.Domain.Entities.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Queries
{
    public class GetByIdTeacherQuery : IRequest<Teacher>
    {
        public Guid Id { get; set; }
    }
}
