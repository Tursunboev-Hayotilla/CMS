using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Commands;
using CMS.Application.UseCases.TeacherCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Handlers.CommandHandlers
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;

        public DeleteTeacherCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id);
                if(teacher == null)
                {
                    return new ResponseModel
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    };
                }
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    Message = "Deleted",
                    StatusCode = 201
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Message = ex.Message,
                    StatusCode = 500
                };
            }
        }
    }
}
