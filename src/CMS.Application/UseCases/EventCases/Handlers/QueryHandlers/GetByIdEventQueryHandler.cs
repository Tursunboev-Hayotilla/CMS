using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Handlers.QueryHandlers
{
    public class GetByIdEventQueryHandler : IRequestHandler<GetByIdEventQuery, Event>
    {
        private readonly ICMSDbContext _context;
        public GetByIdEventQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Event> Handle(GetByIdEventQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Events.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}