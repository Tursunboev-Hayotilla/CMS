using CMS.Application.Abstractions;
using CMS.Application.UseCases.QuizCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Handlers.CommandHandlers
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;

        public CreateQuizCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Quiz quiz =request.Adapt<Quiz>();
                await _context.Quizzes.AddAsync(quiz);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Message = "Created"
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
