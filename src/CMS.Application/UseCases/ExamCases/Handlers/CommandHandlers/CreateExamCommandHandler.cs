using CMS.Application.Abstractions;
using CMS.Application.UseCases.ExamCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamCases.Handlers.CommandHandlers
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public CreateExamCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            await _context.Examines.AddAsync(new Examine()
            {
                Task = request.Task,
                Coin = request.Coin,
                SubjectId = request.SubjectId,
                ClassId = request.ClassId,
                Date = request.Date
            });
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Succesfully created",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}
