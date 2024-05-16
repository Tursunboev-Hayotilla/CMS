using CMS.Application.UseCases.Auth;
using CMS.Application.UseCases.EmailService;
using CMS.Application.UseCases.EmployeeCases.Commands;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EmployeeCases.Handlers.CommandHandler
{
    public class RegisterEmployeeCommandHandler : IRequestHandler<RegisterEmployeeCommand, ResponseModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAuthServise _authService;
        private readonly IEmailService _emailSender;
        public RegisterEmployeeCommandHandler(UserManager<User> userManager, IWebHostEnvironment webHostEnvironment, IAuthServise authServise, IEmailService emailSender)
        {
            _authService = authServise;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;
        }
        public async Task<ResponseModel> Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
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
                PDFFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "EmployeePDF", PDFFileName);

                PhotoFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                PhotoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "EmployeePhoto", PhotoFileName);

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
                var emailBody = $"Dear {request.FirstName},\n\nThank you for registering as a school stuff. Your password is: {Password}.\n\nBest regards,\nThe CMS Team";

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

            var newEmployee = new Employee()
            {
                UserName = request.LastName + request.FirstName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Location = request.Location,
                Gender = request.Gender,
                BirthDate = request.BirthDate,
                PDFPath = "/EmployeePDF/"+PDFFileName,
                PhotoPath = "/EmployeePhoto"+PhotoFileName,
                Role = "HeadTeacher"
            };

            var res = await _userManager.CreateAsync(newEmployee,Password);
            if (!res.Succeeded)
            {
                return new ResponseModel()
                {
                    Message = "Something went wrong",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            var result = await _userManager.AddToRoleAsync(newEmployee, "HeadTeacher");

            return new ResponseModel()
            {
                Message = "Successfully registered",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}
