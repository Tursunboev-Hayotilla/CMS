using CMS.Application.Abstractions;
using CMS.Application.UseCases.HomeWorkCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Handlers.CommandHandlers
{
    public class DeleteHmCommandHandler : IRequestHandler<DeleteHomework, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public DeleteHmCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteHomework request, CancellationToken cancellationToken)
        {
            var res = await _context.Homeworks.FirstOrDefaultAsync(x => x.Id == request.HomeworkId);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            _context.Homeworks.Remove(res);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Deleted",
                IsSuccess = true,
                StatusCode = 203
            };
        }
    }
}
