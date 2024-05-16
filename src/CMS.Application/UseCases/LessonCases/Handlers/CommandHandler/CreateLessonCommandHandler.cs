using CMS.Application.Abstractions;
using CMS.Application.UseCases.LessonCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Handlers.CommandHandler
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public CreateLessonCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var newLesson = new Lesson()
            {
               // Theme = request.Theme,
                Day = request.Day,
                FromTime = request.FromTime,
                ToTime = request.ToTime,
                ClassId = request.ClassId,
                SubjectId = request.SubjectId,
                TeacherId = request.TeacherId
            };
            var res = await _context.Lessons.AddAsync(newLesson);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Created",
                StatusCode = 203,
                IsSuccess = true,
            };
        }
    }
}
