using CMS.Application.Abstractions;
using CMS.Application.UseCases.LessonCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Handlers.CommandHandler
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public UpdateLessonCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Lesson not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            res.Theme = request.Theme;
            res.Day = request.Day;
            res.FromTime = request.FromTime;
            res.ToTime = request.ToTime;
            res.ClassId = request.ClassId;
            res.SubjectId = request.SubjectId;
            res.AttendanceId = request.AttendanceId;
            res.TeacherId = request.TeacherId;

            _context.Lessons.Update(res);
            _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Updated",
                IsSuccess = true,
                StatusCode = 203
            };
        }
    }
}
