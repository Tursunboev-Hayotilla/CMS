using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Handlers.CommandHandlers
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public DeleteEventCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Events.FirstOrDefaultAsync(x => x.Id == request.EventId);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Event not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            _context.Events.Remove(res);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Succesfully deleted",
                IsSuccess = true,
                StatusCode = 203
            };
        }
    }
}
