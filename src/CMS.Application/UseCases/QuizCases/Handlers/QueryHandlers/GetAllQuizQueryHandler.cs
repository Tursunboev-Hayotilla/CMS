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
    public class GetAllQuizQueryHandler : IRequestHandler<GetAllQuizQuery, IEnumerable<Quiz>>
    {
        private readonly ICMSDbContext _context;

        public GetAllQuizQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quiz>> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Quizzes.Skip(request.PageIndex).Take(request.Count).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
