using CMS.Application.Abstractions;
using CMS.Application.UseCases.TeacherCases.Queries;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Handlers.QueryHandlers
{
    public class GetByIdTeacherQueryHandler : IRequestHandler<GetByIdTeacherQuery, Teacher>
    {
        private readonly IApplicationDbContext _context;

        public GetByIdTeacherQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Teacher> Handle(GetByIdTeacherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(a => a.Id == request.Id);
                if (teacher == null)
                {
                    throw new Exception("Not Found");
                }
                return teacher;
            }
            catch (Exception ex)
            {
                throw new Exception("Error❗");
            }
        }
    }

}
