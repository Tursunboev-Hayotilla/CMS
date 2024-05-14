using CMS.Application.Abstractions;
using CMS.Application.UseCases.SchoolCases.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.SchoolCases.Handlers.QueryHandlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllSchoolEmployees, int>
    {
        private readonly ICMSDbContext _context;
        public GetAllEmployeesQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(GetAllSchoolEmployees request, CancellationToken cancellationToken)
        {
            var res =  _context.Teachers.ToList().Count();
            return res += _context.Employees.ToList().Count();
        }
    }
}
