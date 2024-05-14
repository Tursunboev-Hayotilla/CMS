using CMS.Application.Abstractions;
using CMS.Application.UseCases.TeacherCases.Queries;
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
    public class GetAllTeachersBySubjectQueryHandler : IRequestHandler<GetAllTeachersBySubjectQuery, IEnumerable<Teacher>>
    {
        private readonly ICMSDbContext _context;
        public GetAllTeachersBySubjectQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Teacher>> Handle(GetAllTeachersBySubjectQuery request, CancellationToken cancellationToken)
        {
            return await _context.Teachers.Where(t => t.SubjectId == request.Id).ToListAsync(cancellationToken);
        }
    }
}
