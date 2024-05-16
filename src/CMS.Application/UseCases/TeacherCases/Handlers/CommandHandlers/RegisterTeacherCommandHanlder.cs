using CMS.Application.UseCases.Auth;
using CMS.Application.UseCases.EmailService;
using CMS.Application.UseCases.TeacherCases.Commands;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Handlers.CommandHandlers
{
    public class RegisterTeacherCommandHandler : IRequestHandler<RegisterTeacherCommand, ResponseModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAuthServise _authService;
        private readonly IEmailService _emailSender;

        public RegisterTeacherCommandHandler(UserManager<User> userManager, IWebHostEnvironment webHostEnvironment, IAuthServise authServise, IEmailService emailSender)
        {
            _authService = authServise;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;
        }

        public async Task<ResponseModel> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
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
            string PDFFileName = "";
            string PDFFilePath = "";

            string PhotoFileName = "";
            string PhotoFilePath = "";

            try
            {
                PDFFileName = Guid.NewGuid().ToString() + Path.GetExtension(pdf.FileName);
                PDFFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "TeacherPDF", PDFFileName);

                PhotoFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                PhotoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "TeacherPhoto", PhotoFileName);

                using (var stream = new FileStream(PDFFilePath, FileMode.Create))
                {
                    await pdf.CopyToAsync(stream);
                }
                using (var Photostream = new FileStream(PhotoFilePath, FileMode.Create))
                {
                    await photo.CopyToAsync(Photostream);
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
                var emailBody = $"Dear {request.FirstName},\n\nThank you for registering as a teacher. Your password is: {Password}.\n\nBest regards,\nThe CMS Team";

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
                    Message = $"Failed to send password to email",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            var newTeacher = new Teacher()
            {
                UserName = request.FirstName + request.LastName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                SubjectId = request.SubjectId,
                BirthDate = request.BirthDate,
                Location = request.Location,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PDFPath = "/TeacherPDF/" + PDFFileName,
                PhotoPath = "/TeacherPhoto/" + PhotoFileName,
                Role = "Teacher"
            };

            var result = await _userManager.CreateAsync(newTeacher, Password);

            if (!result.Succeeded)
            {
                return new ResponseModel()
                {
                    Message = "Something went wrong",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            var res = await _userManager.AddToRoleAsync(newTeacher, "Teacher");

            return new ResponseModel()
            {
                Message = "Successfully registered",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}
