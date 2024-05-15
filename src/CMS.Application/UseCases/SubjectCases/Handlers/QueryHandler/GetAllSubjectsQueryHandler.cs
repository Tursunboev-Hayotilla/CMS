using CMS.Application.Abstractions;
using CMS.Application.UseCases.SubjectCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.SubjectCases.Handlers.QueryHandler
{
    public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, IEnumerable<Subject>>
    {
        private readonly ICMSDbContext _context;
        public GetAllSubjectsQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Subject>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Subjects.ToListAsync(cancellationToken);
        }
    }
}
