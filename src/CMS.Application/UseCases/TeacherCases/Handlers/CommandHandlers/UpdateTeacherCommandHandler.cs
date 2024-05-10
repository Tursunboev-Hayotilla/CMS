using CMS.Application.Abstractions;
using CMS.Application.UseCases.TeacherCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Handlers.CommandHandlers
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(a => a.Id == request.Id);
                if (teacher == null)
                {
                    return new ResponseModel
                    {
                        Message = "Not Found",
                        StatusCode = 400
                    };
                }

                teacher = request.Adapt<Teacher>();
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Updated",
                    StatusCode = 201,
                    IsSuccess = true
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
