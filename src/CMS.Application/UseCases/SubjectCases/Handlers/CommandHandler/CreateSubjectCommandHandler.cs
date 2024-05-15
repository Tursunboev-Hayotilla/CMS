using CMS.Application.Abstractions;
using CMS.Application.UseCases.SubjectCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.SubjectCases.Handlers.CommandHandler
{
    public class CreateSubjectCommandHandler:IRequestHandler<CreateSubjectCommand,ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public CreateSubjectCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == request.Name);
            if (res == null)
            {
                var newSubject = new Subject()
                {
                    Name = request.Name,
                };
                await _context.Subjects.AddAsync(newSubject);
                await _context.SaveChangesAsync(cancellationToken);
                return new ResponseModel()
                {
                    Message = "Created",
                    StatusCode = 200,
                    IsSuccess = true,
                };
            }
            return new ResponseModel()
            {
                Message = "Already exist",
                StatusCode = 500,
                IsSuccess = false
            };
        }
    }
}
