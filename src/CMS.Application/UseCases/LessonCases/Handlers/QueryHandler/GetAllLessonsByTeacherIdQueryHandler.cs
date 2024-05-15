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

namespace CMS.Application.UseCases.LessonCases.Handlers.QueryHandler
{
    public class GetAllLessonsByTeacherIdQueryHandler : IRequestHandler<GetAllLessonsByTeacherId, IEnumerable<Lesson>>
    {
        private readonly ICMSDbContext _context;
        public GetAllLessonsByTeacherIdQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Lesson>> Handle(GetAllLessonsByTeacherId request, CancellationToken cancellationToken)
        {
            return await _context.Lessons.Where(x => x.TeacherId == request.teacherId).ToListAsync(cancellationToken);
        }
    }
}
