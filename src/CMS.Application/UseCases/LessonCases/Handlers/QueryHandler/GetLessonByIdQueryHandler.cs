using CMS.Application.Abstractions;
using CMS.Application.UseCases.LessonCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Handlers.QueryHandler
{
    public class GetLessonByIdQueryHandler : IRequestHandler<GetLessonByIdQuery, Lesson>
    {
        private readonly ICMSDbContext _context;
        public GetLessonByIdQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Lesson> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}
