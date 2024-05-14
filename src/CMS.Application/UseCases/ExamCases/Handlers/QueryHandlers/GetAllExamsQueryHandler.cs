using CMS.Application.Abstractions;
using CMS.Application.UseCases.ExamCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamCases.Handlers.QueryHandlers
{
    public class GetAllExamsQueryHandler : IRequestHandler<GetAllExamsQuery, List<Examine>>
    {
        private readonly ICMSDbContext _context;
        public GetAllExamsQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<List<Examine>> Handle(GetAllExamsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Examines.ToListAsync(cancellationToken);
        }
    }
}
