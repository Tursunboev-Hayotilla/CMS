using CMS.Application.Abstractions;
using CMS.Application.UseCases.AttendaceCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.AttendaceCases.Handlers.CommandHandlers
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;

        public CreateAttendanceCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

            if (student == null)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Student not found.",
                    StatusCode = 404
                };
            }

            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(x => x.Id == request.LessonId, cancellationToken);

            if (lesson == null)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Lesson not found.",
                    StatusCode = 404
                };
            }

            var attendance = new StudentAttendance
            {
                StudentId = student.Id,
                LessonId = lesson.Id,
                IsPresent = request.IsPresent
            };
            _context.StudentAttendances.Add(attendance);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                IsSuccess = true,
                Message = "Attendance record created successfully.",
                StatusCode = 201
            };
        }
    }
}
