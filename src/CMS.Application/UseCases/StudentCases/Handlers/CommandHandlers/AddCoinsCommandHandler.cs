using CMS.Application.Abstractions;
using CMS.Application.UseCases.StudentCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Handlers.CommandHandlers
{
    public class AddCoinsCommandHandler : IRequestHandler<AddCoinsCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public AddCoinsCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(AddCoinsCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (student == null)
            {
                return new ResponseModel()
                {
                    Message = "Student not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            student.Coin += request.Coin;
            _context.Students.Update(student);
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
