using CMS.Application.Abstractions;
using CMS.Application.UseCases.ExamAppraciate.Commands;
using CMS.Application.UseCases.StundentAppraciateCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamAppraciate.Handlers
{
    public class AppreciateStudentHandler : IRequestHandler<AppreciateStudentsExamCommand, ResponseModel>
    {
        public readonly ICMSDbContext _context;
        public AppreciateStudentHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(AppreciateStudentsExamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exam = _context.Examines.FirstOrDefault(e => e.Id == request.ExamId);
                if (exam == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not found",
                        StatusCode = 404,
                        IsSuccess = false
                    };

                }



                foreach (var student in request.StudentIds)
                {
                    var appreciate = new ExamAppraciateStudent
                    {
                        ExamId = request.ExamId,
                        StudentId = student.Id,
                        Coins = request.Coins
                    };
                    _context.ExamAppraciates.Add(appreciate);
                }

                await _context.SaveChangesAsync(cancellationToken);
                return new ResponseModel()
                {
                    Message = "Added",
                    IsSuccess = true,
                    StatusCode = 203
                };
            }
            catch (Exception)
            {
                return new ResponseModel()
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }
    }
}
