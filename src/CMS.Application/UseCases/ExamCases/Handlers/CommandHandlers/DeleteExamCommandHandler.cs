using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Commands;
using CMS.Application.UseCases.ExamCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamCases.Handlers.CommandHandlers
{
    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public DeleteExamCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.Examines.FirstOrDefaultAsync(x => x.Id == request.ExamId);
            if (exam == null)
            {
                return new ResponseModel()
                {
                    Message = "Exam not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            _context.Examines.Remove(exam);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Succesfully deleted",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}
