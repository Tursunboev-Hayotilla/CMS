using CMS.Application.Abstractions;
using CMS.Application.UseCases.ExamAppraciate.Queries;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamAppraciate.Handlers
{

    public class GetResultsByIdHandler : IRequestHandler<GetResultById, ExamAppraciateStudent>
    {
        private readonly ICMSDbContext _context;
        public GetResultsByIdHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ExamAppraciateStudent> Handle(GetResultById request, CancellationToken cancellationToken)
        {
            try
            {
                var examResult = await _context.ExamAppraciates.FindAsync(request.ExamId);

                return examResult;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
