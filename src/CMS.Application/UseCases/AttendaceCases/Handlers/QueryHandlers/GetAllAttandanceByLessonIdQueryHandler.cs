using CMS.Application.Abstractions;
using CMS.Application.UseCases.AttendaceCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.AttendanceCases.Handlers.QueryHandlers
{
    public class GetAllAttendanceByLessonIdQueryHandler : IRequestHandler<GetAllAttandeceByLesson, IEnumerable<Attendance>>
    {
        private readonly ICMSDbContext _context;

        public GetAllAttendanceByLessonIdQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> Handle(GetAllAttandeceByLesson request, CancellationToken cancellationToken)
        {
            return await _context.Attendances
                .Include(a => a.StudentAttendance)
                .Where(a => a.StudentAttendance.LessonId == request.lessonId)
                .ToListAsync(cancellationToken);
        }
    }
}
