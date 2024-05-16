using CMS.Application.Abstractions;
using CMS.Application.UseCases.ClassCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ClassCases.Handlers.QueryHandler
{
    public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery, IEnumerable<Class>>
    {
        private readonly ICMSDbContext _context;
        public GetAllClassesQueryHandler(ICMSDbContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Class>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Classes
               .Include(c => c.Subjects)
               .ToListAsync(cancellationToken);
        }
    }
}
