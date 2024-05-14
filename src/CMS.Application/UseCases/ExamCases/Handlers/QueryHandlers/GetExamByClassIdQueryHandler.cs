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
    public class GetExamByClassIdQueryHandler : IRequestHandler<GetAllExamByClassIdQuery, List<Examine>>
    {
        private readonly ICMSDbContext _context;
        public GetExamByClassIdQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<List<Examine>> Handle(GetAllExamByClassIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Examines.Where(x => x.ClassId == request.ClassId).ToListAsync(); 
        }
    }
}