using CMS.Application.Abstractions;
using CMS.Application.UseCases.SubjectCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.SubjectCases.Handlers.CommandHandler
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSUbjectCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public UpdateSubjectCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateSUbjectCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Subject not found",
                    IsSuccess = false,
                    StatusCode = 404,
                };
            }
            res.Name = request.Name;
            _context.Subjects.Update(res);
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
