using CMS.Application.Abstractions;
using CMS.Application.UseCases.StudentCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        public DeleteStudentCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment,IMemoryCache memoryCache)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _memoryCache = memoryCache;
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
            _memoryCache.Remove("allstudents");

            return new ResponseModel()
            {
                Message = "Student deleted successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}