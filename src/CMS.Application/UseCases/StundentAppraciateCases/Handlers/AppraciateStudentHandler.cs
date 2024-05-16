using CMS.Application.Abstractions;
using CMS.Application.UseCases.StundentAppraciateCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StundentAppraciateCases.Handlers
{
    public class AppraciateStudentHandler : IRequestHandler<AppraciateStudentCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public AppraciateStudentHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(AppraciateStudentCommand request, CancellationToken cancellationToken)
        {
            var newAppraciate = new StudentAppraciate()
            {
                studentId = request.studentId,
                LessonId = request.LessonId,
                LessonCoin = request.LessonCoin,
                HomeworkCoin = request.HomeworkCoin,
            };
            await _context.StudentAppraciates.AddAsync(newAppraciate);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Added",
                IsSuccess = true,
                StatusCode = 200
            };
        }
    }
}
