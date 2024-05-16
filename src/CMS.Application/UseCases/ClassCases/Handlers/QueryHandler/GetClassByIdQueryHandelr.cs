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
    public class GetClassByIdQueryHandelr : IRequestHandler<GetClassByIdQuery, Class>
    {
        private readonly ICMSDbContext _context;
        public GetClassByIdQueryHandelr(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Class> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Classes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}
