using CMS.Application.Abstractions;
using CMS.Application.UseCases.QuizCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Handlers.QueryHandlers
{
    public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, Quiz>
    {
        private readonly ICMSDbContext _context;

        public GetQuizByIdQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<Quiz> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Quiz quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == request.Id);
                if (quiz == null)
                {
                    throw new Exception("Not Found");
                }
                return quiz;
            }
            catch (Exception ex)
            {
                throw new Exception("Somethign went wrong");
            }
        }
    }
}
