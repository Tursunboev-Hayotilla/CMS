using CMS.Application.Abstractions;
using CMS.Application.UseCases.StudentCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Handlers.CommandHandlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteStudentCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.Id);

            if (student == null)
            {
                return new ResponseModel()
                {
                    Message = "Student not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            var photoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, student.PhotoPath.TrimStart('/'));
            if (File.Exists(photoFilePath))
            {
                File.Delete(photoFilePath);
            }

            var pdfFilePath = Path.Combine(_webHostEnvironment.WebRootPath, student.PDFPath.TrimStart('/'));
            if (File.Exists(pdfFilePath))
            {
                File.Delete(pdfFilePath);
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                Message = "Student deleted successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}