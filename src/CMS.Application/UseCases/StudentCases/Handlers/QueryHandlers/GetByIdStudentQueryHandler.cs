using CMS.Application.Abstractions;
using CMS.Application.UseCases.StudentCases.Queries;
using CMS.Domain.Entities.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Handlers.QueryHandlers
{
    public class GetByIdStudentQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly ICMSDbContext _context;
        public GetByIdStudentQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Students.FirstOrDefaultAsync(x=> x.Id == request.Id);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}
