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
    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public CreateClassCommandHandler(ICMSDbContext context)
        {
            _context = context; 
        }
        public async Task<ResponseModel> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Classes.FirstOrDefaultAsync(x => x.Name == request.Name && x.Grade == request.Grade);
            if (res != null)
            {
                return new ResponseModel()
                {
                    Message = "Already exist",
                    IsSuccess = false,
                    StatusCode = 403
                };
            }
            var newClass = new Class()
            {
                Name = request.Name,
                TeacherId = request.TeacherId,
                Grade = request.Grade,
            };
            await _context.Classes.AddAsync(newClass);

            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Created",
                IsSuccess = true,
                StatusCode = 203
            };
        }
    }
}
