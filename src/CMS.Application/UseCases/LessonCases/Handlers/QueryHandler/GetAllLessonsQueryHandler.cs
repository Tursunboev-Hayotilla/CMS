using CMS.Application.Abstractions;
using CMS.Application.UseCases.LessonCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Handlers.QUeryHandler
{
    public class GetAllLessonsQueryHandler : IRequestHandler<GetAllLessonQuery, IEnumerable<Lesson>>
    {
        private readonly ICMSDbContext _context;
        public GetAllLessonsQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Lesson>> Handle(GetAllLessonQuery request, CancellationToken cancellationToken)
        {
            return await _context.Lessons.ToListAsync(cancellationToken);
        }
    }
}
