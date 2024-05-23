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
    public class StartLessonCommandHandler : IRequestHandler<StartLessonCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public StartLessonCommandHandler(ICMSDbContext context)
        {
            _context =  context;
        }
        public async Task<ResponseModel> Handle(StartLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == request.LessonId);
            if (lesson == null)
            {
                return new ResponseModel()
                {
                    Message = "Lesson not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            lesson.Theme = request.Theme;
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Started",
                IsSuccess = true,
                StatusCode = 201
            };
        }
    }
}
