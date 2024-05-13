using CMS.Application.UseCases.Auth;
using CMS.Application.UseCases.TeacherCases.Commands;
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

namespace CMS.Application.UseCases.TeacherCases.Handlers.CommandHandlers
{
    public class RegisterTeacherCommandHanlder : IRequestHandler<RegisterTeacherCommand, ResponseModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAuthServise _authService;
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
            var newTeacher = new Teacher()
            {
                UserName = request.FirstName + request.LastName,
                FirstName = request.FirstName,
                LastName = request  .LastName,
                Gender = request.Gender,
                SubjectId = request.SubjectId,
                Location = request.Location,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PDFPath = "/TeacherPDF/" + PDFFileName,
                PhotoPath = "/TeacherPhoto/" + PhotoFileName,
                Role = "Teacher"
            };

            var result = await _userManager.CreateAsync(newTeacher, request.Password);

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
            Console.WriteLine();
            return new ResponseModel()
            {
                Message = "Succesfully registered",
                StatusCode = 203,
                IsSuccess = true
            };
        }
    }
}
