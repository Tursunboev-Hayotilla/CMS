using CMS.Application.Abstractions;
using CMS.Application.UseCases.SubjectCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.SubjectCases.Handlers.QueryHandler
{
    public class GetSubjectByIdQuery : IRequestHandler<GetSubjectById, Subject>
    {
        private readonly ICMSDbContext _context;
        public GetSubjectByIdQuery(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Subject> Handle(GetSubjectById request, CancellationToken cancellationToken)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
