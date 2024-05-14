using CMS.Application.Abstractions;
using CMS.Application.UseCases.QuizCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Handlers.QueryHandlers
{
    public class GetQuizByLessonId : IRequestHandler<GetQuizByLessonIdQuery, Quiz>
    {
        private readonly ICMSDbContext _context;
        public GetQuizByLessonId(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Quiz> Handle(GetQuizByLessonIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Quizzes.FirstOrDefaultAsync(x => x.LessonId == request.LessonId);
        }
    }
}
