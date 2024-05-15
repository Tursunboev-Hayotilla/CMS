using CMS.Application.Abstractions;
using CMS.Application.UseCases.SubjectCases.Commands;
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
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, ResponseModel>
    {
        private ICMSDbContext _context;
        public DeleteSubjectCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Subject not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            _context.Subjects.Remove(res);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Deleted",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}
