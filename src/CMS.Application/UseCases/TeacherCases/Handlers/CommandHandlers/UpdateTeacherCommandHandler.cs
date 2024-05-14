using CMS.Application.Abstractions;
using CMS.Application.UseCases.TeacherCases.Commands;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Handlers.CommandHandlers
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateTeacherCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve the teacher entity from the database
                var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == request.Id);

                if (teacher == null)
                {
                    return new ResponseModel
                    {
                        Message = "Teacher not found",
                        StatusCode = 404
                    };
                }

                request.Adapt(teacher);

                if (request.Photo != null)
                {
                    var existingPhotoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, teacher.PhotoPath.TrimStart('/'));
                    if (File.Exists(existingPhotoFilePath))
                    {
                        File.Delete(existingPhotoFilePath);
                    }

                    var photoFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
                    var photoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "TeacherPhoto", photoFileName);
                    using (var stream = new FileStream(photoFilePath, FileMode.Create))
                    {
                        await request.Photo.CopyToAsync(stream);
                    }
                    teacher.PhotoPath = "/TeacherPhoto/" + photoFileName;
                }

                if (request.PDF != null)
                {
                    var existingPdfFilePath = Path.Combine(_webHostEnvironment.WebRootPath, teacher.PDFPath.TrimStart('/'));
                    if (File.Exists(existingPdfFilePath))
                    {
                        File.Delete(existingPdfFilePath);
                    }

                    var pdfFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.PDF.FileName);
                    var pdfFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "TeacherPDF", pdfFileName);
                    using (var stream = new FileStream(pdfFilePath, FileMode.Create))
                    {
                        await request.PDF.CopyToAsync(stream);
                    }
                    teacher.PDFPath = "/TeacherPDF/" + pdfFileName;
                }

                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Teacher updated successfully",
                    StatusCode = 200,
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
