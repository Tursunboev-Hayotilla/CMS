using CMS.Application.Abstractions;
using CMS.Application.UseCases.ExamAppraciate.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamAppraciate.Handlers
{
    public class UpdateExamAppriciateHandler : IRequestHandler<Update, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        public UpdateExamAppriciateHandler(ICMSDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(Update request, CancellationToken cancellationToken)
        {
            try
            {
                var exam = _context.Examines.FirstOrDefault(e => e.Id == request.ExamId);
                if (exam == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Exam not found",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                foreach (var student in request.StudentIds)
                {
                    var appreciate = _context.ExamAppraciates.FirstOrDefault(a => a.ExamId == request.ExamId && a.StudentId == student.Id);
                    if (appreciate != null)
                    {
                        appreciate.Coins = request.Coins;
                    }
                    else
                    {
                        // If appreciation doesn't exist, create a new one
                        appreciate = new ExamAppraciateStudent
                        {
                            ExamId = request.ExamId,
                            StudentId = student.Id,
                            Coins = request.Coins
                        };
                        _context.ExamAppraciates.Add(appreciate);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Appreciation updated successfully",
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = $"Error: {ex.Message}",
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }
    }
}