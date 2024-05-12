using CMS.Application.Abstractions;
using CMS.Application.UseCases.TeacherCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Handlers.CommandHandlers
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;

        public CreateTeacherCommandHandler(ICMSDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Teacher teacher = request.Adapt<Teacher>();
                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Teacher created",
                    IsSuccess = true,
                    StatusCode = 201
                };
            }
            catch(Exception ex)
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
