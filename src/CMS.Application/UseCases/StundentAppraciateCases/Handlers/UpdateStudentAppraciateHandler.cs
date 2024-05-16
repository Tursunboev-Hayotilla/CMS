using CMS.Application.Abstractions;
using CMS.Application.UseCases.SchoolCases.Commands;
using CMS.Application.UseCases.StundentAppraciateCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StundentAppraciateCases.Handlers
{
    public class UpdateStudentAppraciateHandler : IRequestHandler<UpdateStudentAppraciateCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public UpdateStudentAppraciateHandler(ICMSDbContext context)
        {
            _context =  context;
        }
        public async Task<ResponseModel> Handle(UpdateStudentAppraciateCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.StudentAppraciates.FirstOrDefaultAsync(x => x.studentId == request.studentId && x.LessonId == request.LessonId);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            res.LessonCoin = request.LessonCoin;
            res.HomeworkCoin = request.HomeworkCoin;
            return new ResponseModel()
            {
                Message = "Updated",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}
