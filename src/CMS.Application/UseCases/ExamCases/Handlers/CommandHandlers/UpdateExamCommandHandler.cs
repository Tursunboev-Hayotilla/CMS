using CMS.Application.Abstractions;
using CMS.Application.UseCases.ExamCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamCases.Handlers.CommandHandlers
{
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public UpdateExamCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Examines.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Exam not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            res.Task = request.Task;
            res.Coin = request.Coin;
            res.SubjectId = request.SubjectId;
            res.ClassId = request.ClassId;
            res.Date = request.Date;

            _context.Examines.Update(res);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Saccesfully updated",
                StatusCode = 203,
                IsSuccess = true
            };
        }

    }
}
