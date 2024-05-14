using CMS.Application.Abstractions;
using CMS.Application.UseCases.SchoolCases.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.SchoolCases.Handlers.QueryHandlers
{
    public class GetAllSchoolsStudents : IRequestHandler<GetAllSchoolsStudentsQuery, int>
    {
        private readonly ICMSDbContext _context;
        public GetAllSchoolsStudents(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(GetAllSchoolsStudentsQuery request, CancellationToken cancellationToken)
        {
            return  _context.Students.ToList().Count();
        }
    }
}
