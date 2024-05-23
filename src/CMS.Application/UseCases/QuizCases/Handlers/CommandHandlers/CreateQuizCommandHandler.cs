using CMS.Application.Abstractions;
using CMS.Application.UseCases.QuizCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Handlers.CommandHandlers
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateQuizCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var photo = request.DescriptionPhoto;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Quiz", fileName);

            try
            {
                var quizDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Quiz");
                if (!Directory.Exists(quizDirectory))
                {
                    Directory.CreateDirectory(quizDirectory);
                }

                // Upload the photo
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
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

            try
            {
                Quiz quiz = request.Adapt<Quiz>();
                quiz.DescriptionPhotoPath = "/Quiz/" + fileName;
                await _context.Quizzes.AddAsync(quiz, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Message = "Created"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
        }
    }
}
