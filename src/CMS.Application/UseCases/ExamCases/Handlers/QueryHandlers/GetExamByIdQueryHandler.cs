using CMS.Application.Abstractions;
using CMS.Application.UseCases.ExamCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamCases.Handlers.QueryHandlers
{
    public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, Examine>
    {
        private readonly ICMSDbContext _context;
        public GetExamByIdQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<Examine> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Examines.FirstOrDefaultAsync(x => x.Id == request.ExamId);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}
