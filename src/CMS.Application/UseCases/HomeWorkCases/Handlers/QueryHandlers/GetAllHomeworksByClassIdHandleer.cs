using CMS.Application.Abstractions;
using CMS.Application.UseCases.HomeWorkCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Handlers.QueryHandlers
{
    public class GetAllHomeworksByClassIdHandler : IRequestHandler<GetAllHomeworksByClassId, IEnumerable<Homework>>
    {
        private readonly ICMSDbContext _context;

        public GetAllHomeworksByClassIdHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Homework>> Handle(GetAllHomeworksByClassId request, CancellationToken cancellationToken)
        {
            try
            {
                var homeworks = await _context.Homeworks
                    .Where(h => h.Lesson.ClassId == request.ClassId)
                    .ToListAsync(cancellationToken);

                return homeworks;
            }
            catch
            {
                return null;
            }
        }
    }
}
