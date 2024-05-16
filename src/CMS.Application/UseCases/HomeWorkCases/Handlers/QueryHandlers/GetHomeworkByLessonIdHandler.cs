using CMS.Application.Abstractions;
using CMS.Application.UseCases.HomeWorkCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Handlers.QueryHandlers
{
    public class GetHomeworkByLessonIdHandler : IRequestHandler<GetHomeworkByLesson, Homework>
    {
        private readonly ICMSDbContext _context;
        public GetHomeworkByLessonIdHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Homework> Handle(GetHomeworkByLesson request, CancellationToken cancellationToken)
        {
            var res = await _context.Homeworks.FirstOrDefaultAsync(x => x.LessonId == request.LessonId);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}
