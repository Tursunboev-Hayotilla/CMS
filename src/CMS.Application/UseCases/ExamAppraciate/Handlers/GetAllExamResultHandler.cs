using CMS.Application.Abstractions;
using CMS.Application.UseCases.ExamAppraciate.Queries;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamAppraciate.Handlers
{
    public class GetAllExamResultHandler : IRequestHandler<GetAllExamResultsByClassId, List<ExamAppraciateStudent>>
    {
        private readonly ICMSDbContext _context;
        public GetAllExamResultHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExamAppraciateStudent>> Handle(GetAllExamResultsByClassId request, CancellationToken cancellationToken)
        {
            try
            {
                var examResults = await _context.ExamAppraciates
                    .Include(e => e.Student)
                    .Where(e => e.Student.ClassId == request.ClassId)
                    .ToListAsync(cancellationToken);

                return examResults;
            }
            catch 
            {
                return null;
            }
        }
    }
}
