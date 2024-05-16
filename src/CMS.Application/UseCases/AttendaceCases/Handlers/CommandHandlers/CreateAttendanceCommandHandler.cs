using CMS.Application.Abstractions;
using CMS.Application.UseCases.AttendaceCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var students = await _context.Students
                   .Where(s => s.ClassId == request.ClassId)
                   .ToListAsync(cancellationToken);

            foreach (var student in students)
            {
                var attendance = new StudentAttendance
                {
                    StudentId = student.Id,
                    LessonId = request.LessonId,
                    IsPresent = request.IsPresent
                };
                _context.StudentAttendances.Add(attendance);
            }
            var les = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == request.LessonId);
            les.Theme = request.Theme;
            _context.Lessons.Update(les);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                IsSuccess = true,
                Message = "Attendance records created successfully.",
                StatusCode = 203
            };
        }
    }
}
