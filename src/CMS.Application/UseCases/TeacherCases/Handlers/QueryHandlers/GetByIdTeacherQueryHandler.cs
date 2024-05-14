using CMS.Application.Abstractions;
using CMS.Application.UseCases.TeacherCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Handlers.QueryHandlers
{
    public class GetByIdTeacherQueryHandler : IRequestHandler<GetByIdTeacherQuery, Teacher>
    {
        private readonly ICMSDbContext _context;

        public GetByIdTeacherQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Teacher> Handle(GetByIdTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (teacher == null)
            {
                return null;
            }
            return teacher;

        }
    }

}
