using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Queries;
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
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly ICMSDbContext _context;
        public GetAllStudentQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.OrderByDescending(s => s.Coin).ToListAsync(cancellationToken); 
        }
    } 
}
