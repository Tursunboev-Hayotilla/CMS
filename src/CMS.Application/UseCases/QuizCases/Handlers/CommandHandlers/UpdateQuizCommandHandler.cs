using CMS.Application.Abstractions;
using CMS.Application.UseCases.QuizCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Handlers.CommandHandlers
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;

        public UpdateQuizCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Quiz quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == request.Id);
                if (quiz == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Message = "Not Found"
                    };
                }

                quiz = request.Adapt<Quiz>();
                _context.Quizzes.Update(quiz);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 202,
                    Message = "Updated"
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
