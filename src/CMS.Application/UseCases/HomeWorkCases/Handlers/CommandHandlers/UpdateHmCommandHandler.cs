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
    public class UpdateHmCommandHandler : IRequestHandler<UpdateHomeworkCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public UpdateHmCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateHomeworkCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Homeworks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            res.TZ = request.TZ;
            _context.Homeworks.Update(res);
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
