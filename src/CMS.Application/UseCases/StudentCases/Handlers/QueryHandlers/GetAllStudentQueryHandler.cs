using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Queries;
using CMS.Application.UseCases.StudentCases.Queries;
using CMS.Domain.Entities.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Handlers.QueryHandlers
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly ICMSDbContext _context;
        private readonly IMemoryCache _memoryCache;
        public GetAllStudentQueryHandler(ICMSDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var cacheData = _memoryCache.Get("allstudents");
            if (cacheData == null)
            {

                var students = await _context.Students.OrderByDescending(s => s.Coin).ToListAsync(cancellationToken);
                _memoryCache.Set("allstudents", students, new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1),
                    SlidingExpiration = TimeSpan.FromSeconds(20),
                });
                return students;
            }
            return  cacheData as IEnumerable<Student>;
        }
    }
}
