using CMS.Application.Abstractions;
using CMS.Application.UseCases.AttendaceCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.AttendanceCases.Handlers.CommandHandlers
{
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;

        public UpdateAttendanceCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var students = await _context.Students
                .Where(s => s.ClassId == request.ClassId)
                .ToListAsync(cancellationToken);

            if (!students.Any())
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "No students found in the specified class.",
                    StatusCode = 404
                };
            }

            foreach (var student in students)
            {
                var attendance = await _context.StudentAttendances
                    .FirstOrDefaultAsync(sa => sa.StudentId == student.Id && sa.LessonId == request.LessonId);

                if (attendance == null)
                {
                    attendance = new StudentAttendance
                    {
                        StudentId = student.Id,
                        LessonId = request.LessonId,
                        IsPresent = request.IsPresent
                    };
                    _context.StudentAttendances.Add(attendance);
                }
                else
                {
                    attendance.IsPresent = request.IsPresent;
                    _context.StudentAttendances.Update(attendance);
                }
            }

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = $"Failed to update attendance records: {ex.Message}",
                    StatusCode = 500
                };
            }

            return new ResponseModel
            {
                IsSuccess = true,
                Message = "Attendance records updated successfully.",
                StatusCode = 200
            };
        }
    }
}
