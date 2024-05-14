using CMS.Application.Abstractions;
using CMS.Application.UseCases.QuizCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Handlers.CommandHandlers
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;

        public DeleteQuizCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == request.Id);
                if (quiz == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = "Not Found"
                    };
                }
                _context.Quizzes.Remove(quiz);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 203,
                    Message = "Deleted"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
        }
    }
}
