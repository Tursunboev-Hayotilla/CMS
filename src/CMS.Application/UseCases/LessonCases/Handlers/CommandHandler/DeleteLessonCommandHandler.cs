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
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public DeleteLessonCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == request.lessonId);
            if (res == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Not found"
                };
            }
            _context.Lessons.Remove(res);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Deleted",
                IsSuccess = true,
                StatusCode = 203
            };
        }
    }
}
