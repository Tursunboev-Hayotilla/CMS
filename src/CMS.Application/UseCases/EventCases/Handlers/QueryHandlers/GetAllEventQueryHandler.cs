using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Handlers.QueryHandlers
{
    public class GetAllEventQueryHandler : IRequestHandler<GetAllEventQuery, IEnumerable<Event>>
    {
        private readonly ICMSDbContext _context;
        public GetAllEventQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Event>> Handle(GetAllEventQuery request, CancellationToken cancellationToken)
        {
            return await _context.Events.ToListAsync(cancellationToken);
        }
    }
}
