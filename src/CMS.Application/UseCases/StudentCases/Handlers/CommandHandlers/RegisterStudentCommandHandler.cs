using CMS.Application.UseCases.Auth;
using CMS.Application.UseCases.EmailService;
using CMS.Application.UseCases.StudentCases.Commands;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Handlers.CommandHandlers
{
    public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, ResponseModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAuthServise _authService;
        private readonly IEmailService _emailSender;
        private readonly IMemoryCache _memoryCache;

        public RegisterStudentCommandHandler(UserManager<User> userManager, IWebHostEnvironment webHostEnvironment, IAuthServise authService, IEmailService emailSender, IMemoryCache memoryCache)
        {
            _authService = authService;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;
            _memoryCache = memoryCache;
        }

        public async Task<ResponseModel> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
            {
                return new ResponseModel()
                {
                    Message = "Email already taken",
                    StatusCode = 403,
                    IsSuccess = false
                };
            }

            var photo = request.Photo;
            var pdf = request.PDF;
            string PDFFileName = Guid.NewGuid().ToString() + Path.GetExtension(pdf.FileName);
            string PDFFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "StudentPDF", PDFFileName);

            string PhotoFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            string PhotoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "StudentPhoto", PhotoFileName);

            try
            {
                // Ensure the directories exist
                var studentPDFDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "StudentPDF");
                var studentPhotoDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "StudentPhoto");

                if (!Directory.Exists(studentPDFDirectory))
                {
                    Directory.CreateDirectory(studentPDFDirectory);
                }

                if (!Directory.Exists(studentPhotoDirectory))
                {
                    Directory.CreateDirectory(studentPhotoDirectory);
                }

                // Upload PDF and Photo
                using (var stream = new FileStream(PDFFilePath, FileMode.Create))
                {
                    await pdf.CopyToAsync(stream);
                }

                using (var photoStream = new FileStream(PhotoFilePath, FileMode.Create))
                {
                    await photo.CopyToAsync(photoStream);
                }
            }
            catch
            {
                return new ResponseModel()
                {
                    Message = "Something went wrong",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            var Password = new Random().Next(100000, 999999).ToString();
            try
            {
                var emailBody = $"Dear {request.FirstName},\n\nThank you for registering as a student. Your password is: {Password}.\n\nBest regards,\nThe CMS Team";

                await _emailSender.SendEmailAsync(new EmailModel
                {
                    To = request.Email,
                    Subject = "Registration Confirmation",
                    Body = emailBody
                });
            }
            catch
            {
                return new ResponseModel()
                {
                    Message = "Failed to send password to email",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            var newStudent = new Student()
            {
                UserName = request.LastName + request.FirstName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                ClassId = request.ClassId,
                PhoneNumber = request.PhoneNumber,
                ParentsPhoneNumber = request.ParentsPhoneNumber,
                Location = request.Location,
                PhotoPath = "/StudentPhoto/" + PhotoFileName,
                PDFPath = "/StudentPDF/" + PDFFileName,
                Role = "Student"
            };

            var res = await _userManager.CreateAsync(newStudent, Password);
            if (!res.Succeeded)
            {
                return new ResponseModel()
                {
                    Message = "Something went wrong",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            await _userManager.AddToRoleAsync(newStudent, "Student");

            _memoryCache.Remove("allstudents");

            return new ResponseModel()
            {
                Message = "Successfully registered",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}
