using CMS.Application.Abstractions;
using CMS.Application.UseCases.LessonCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.LessonCases.Handlers.QueryHandler
{
    public class GetAllLessonsByClassIdQueryHandler : IRequestHandler<GetAllLessonByClassId, IEnumerable<Lesson>>
    {
        private readonly ICMSDbContext _contex;
        public GetAllLessonsByClassIdQueryHandler(ICMSDbContext context)
        {
            _contex = context;
        }
        public async Task<IEnumerable<Lesson?>> Handle(GetAllLessonByClassId request, CancellationToken cancellationToken)
        {
            return await _contex.Lessons.Where(x => x.ClassId == request.classId).ToListAsync(cancellationToken);
        }
    }
}
