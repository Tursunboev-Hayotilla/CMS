using CMS.Application.Abstractions;
using CMS.Application.UseCases.HomeWorkCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Handlers.CommandHandlers
{
    public class CreateHmCommandHandler : IRequestHandler<CreateHomeworkCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public CreateHmCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateHomeworkCommand request, CancellationToken cancellationToken)
        {
            var res = new Homework()
            {
                TZ = request.TZ,
                LessonId = request.LessonId
            };
            _context.Homeworks.Add(res);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Created",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}