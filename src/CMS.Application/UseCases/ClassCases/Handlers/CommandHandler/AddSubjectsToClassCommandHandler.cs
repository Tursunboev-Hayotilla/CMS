using CMS.Application.Abstractions;
using CMS.Application.UseCases.ClassCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ClassCases.Handlers.CommandHandler
{
    public class AddSubjectsToClassCommandHandler : IRequestHandler<AddSubjectsToClass, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public AddSubjectsToClassCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(AddSubjectsToClass request, CancellationToken cancellationToken)
        {
            var res = await _context.Classes.FirstOrDefaultAsync(x => x.Id == request.classId);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Class not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            foreach(var r in request.Subjects)
            {
                var sub = new Subject()
                {
                    Name = r,
                };
                res.Subjects.Add(sub);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Added",
                IsSuccess = true,
                StatusCode = 203
            };
        }
    }
}
