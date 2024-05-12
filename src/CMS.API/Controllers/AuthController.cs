using CMS.Application.UseCases.Auth;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthServise _authServise;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AuthController(UserManager<User> userManager, IAuthServise authServise, IWebHostEnvironment webHostEnvironment)
        {
            _authServise = authServise;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpPost]
        public async Task<ResponseModel> TeacherRegister(TeacherRegisterDTO teacher)
        {
            var userExists = await _userManager.FindByEmailAsync(teacher.Email);
            if (userExists != null)
            {
                return new ResponseModel()
                {
                    Message = "Email already taken",
                    StatusCode = 403,
                    IsSuccess = false
                };
            }
            var photo = teacher.Photo;
            var pdf = teacher.PDF;
            string PDFFileName= "";
            string PDFFilePath = "";

            string PhotoFileName = "";
            string PhotoFilePath = "";

            try
            {
                PDFFileName = Guid.NewGuid().ToString() + Path.GetExtension(pdf.FileName);
                PDFFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "TeacherPDF", PDFFileName);

                PhotoFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                PhotoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "TeacherPhoto", PhotoFileName);

                using(var stream = new FileStream(PDFFilePath, FileMode.Create))
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
                UserName = teacher.FirstName + teacher.LastName,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Gender = teacher.Gender,
                SubjectId = teacher.SubjectId,
                Location = teacher.Location,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
                PDFPath = "/TeacherPDF/" +PDFFileName,
                PhotoPath = "/TeacherPhoto/"+PhotoFileName,
                Role = "Teacher"
            };

            var result = await _userManager.CreateAsync(newTeacher,teacher.Password);

            if (!result.Succeeded)
            {
                return new ResponseModel()
                {
                    Message = "Something went wrong",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            var res =  await _userManager.AddToRoleAsync(newTeacher,"Teacher");
            Console.WriteLine();
            return new ResponseModel()
            {
                Message = "Succesfully registered",
                StatusCode = 203,
                IsSuccess = true
            };
            
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if(user == null)
            {
                throw new Exception();
            }
            var checker = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!checker)
            {
                throw new Exception();
            }
            var token = await _authServise.GenerateToken(user);
            return Ok(token);
        }
    }
}