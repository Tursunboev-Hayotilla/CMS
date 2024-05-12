using CMS.Application.Abstractions;
using CMS.Application.UseCases.TeacherCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Handlers.QueryHandlers
{
    public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQuery, IEnumerable<Teacher>>
    {
        private readonly ICMSDbContext _context;

        public GetAllTeacherQueryHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Teachers.Skip(request.PageIndex).Take(request.Count).ToListAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }

}
