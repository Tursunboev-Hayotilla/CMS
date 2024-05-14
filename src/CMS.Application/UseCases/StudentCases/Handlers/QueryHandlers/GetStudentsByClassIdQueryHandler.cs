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
    public class GetStudentsByClassIdQueryHandler : IRequestHandler<GetStudentsByClassIdQuery, IEnumerable<Student>>
    {
        private readonly ICMSDbContext _context;
        public GetStudentsByClassIdQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> Handle(GetStudentsByClassIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.Where(x => x.ClassId == request.Id).ToListAsync();
        }
    }
}
