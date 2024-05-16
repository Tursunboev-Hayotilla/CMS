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
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public DeleteClassCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Classes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            _context.Classes.Remove(res);
            return new ResponseModel()
            {
                Message = "Deleted",
                IsSuccess = true,
                StatusCode = 203
            };
        }

    }
}
