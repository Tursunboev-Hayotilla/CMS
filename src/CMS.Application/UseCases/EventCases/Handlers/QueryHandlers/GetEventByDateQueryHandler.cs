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
    public class GetEventByDateQueryHandler : IRequestHandler<GetEventByDateQuery, Event>
    {
        private readonly ICMSDbContext _context;
        public GetEventByDateQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Event> Handle(GetEventByDateQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Events.FirstOrDefaultAsync(x => x.Date.Day == request.Day && x.Date.Month == request.Month);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}
