using CMS.Application.Abstractions;
using CMS.Application.UseCases.ClassCases.Commands;
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
    public class UpdateClassCommandHadler : IRequestHandler<UpdateClassCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public UpdateClassCommandHadler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Classes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Class not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            res.Name = request.Name;
            res.Grade = request.Grade;
            res.Subjects = request.Subjects;
            _context.Classes.Update(res);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Updated",
                IsSuccess = true,
                StatusCode = 203
            };
        }
    }
}
