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
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMemoryCache _memoryCache;
        public UpdateStudentCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment,IMemoryCache memoryCache)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _memoryCache = memoryCache;
        }

        public async Task<ResponseModel> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
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

            // Update student's information
            student.FirstName = request.FirsName;
            student.LastName = request.LastName;
            student.Gender = request.Gender;
            student.DateOfBirth = request.DateOfBirth;
            student.ParentsPhoneNumber = request.ParentsPhoneNumber;
            student.ClassId = request.ClassId;
            student.Location = request.Location;

            if (request.Photo != null)
            {
                var existingPhotoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, student.PhotoPath.TrimStart('/'));
                if (File.Exists(existingPhotoFilePath))
                {
                    File.Delete(existingPhotoFilePath);
                }

                var photoFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
                var photoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "StudentPhoto", photoFileName);
                using (var stream = new FileStream(photoFilePath, FileMode.Create))
                {
                    await request.Photo.CopyToAsync(stream);
                }
                student.PhotoPath = "/StudentPhoto/" + photoFileName;
            }

            if (request.PDF != null)
            {
                var existingPdfFilePath = Path.Combine(_webHostEnvironment.WebRootPath, student.PDFPath.TrimStart('/'));
                if (File.Exists(existingPdfFilePath))
                {
                    File.Delete(existingPdfFilePath);
                }

                var pdfFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.PDF.FileName);
                var pdfFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "StudentPDF", pdfFileName);
                using (var stream = new FileStream(pdfFilePath, FileMode.Create))
                {
                    await request.PDF.CopyToAsync(stream);
                }
                student.PDFPath = "/StudentPDF/" + pdfFileName;
            }

            await _context.SaveChangesAsync(cancellationToken);
            _memoryCache.Remove("allstudents");
            return new ResponseModel()
            {
                Message = "Student updated successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}