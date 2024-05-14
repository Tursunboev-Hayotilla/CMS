using CMS.Application.Abstractions;
using CMS.Application.UseCases.QuizCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Handlers.CommandHandlers
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        private readonly IWebHostEnvironment _webhostEnvironment;
        public CreateQuizCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webhostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var photo = request.DescriptionPhoto;
            string FileName = "";
            string FilePath = "";

            try
            {
                FileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                FilePath = Path.Combine(_webhostEnvironment.WebRootPath, "Quiz", FileName);

                using (var stream = new FileStream(FilePath, FileMode.Create))
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
                quiz.DescriptionPhotoPath = "/Quiz/" + FileName;
               var res = await _context.Quizzes.AddAsync(quiz);
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
