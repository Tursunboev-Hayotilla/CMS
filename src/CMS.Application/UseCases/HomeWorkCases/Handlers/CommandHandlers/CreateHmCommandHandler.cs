using CMS.Application.Abstractions;
using CMS.Application.UseCases.HomeWorkCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Handlers.CommandHandlers
{
    public class CreateHmCommandHandler : IRequestHandler<CreateHomeworkCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateHmCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateHomeworkCommand request, CancellationToken cancellationToken)
        {
            var lessonExists = await _context.Lessons
                                              .AnyAsync(l => l.Id == request.LessonId, cancellationToken);

            if (!lessonExists)
            {
                return new ResponseModel
                {
                    Message = "Lesson not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            var homework = new Homework
            {
                Task = request.TZ,
                LessonId = request.LessonId
            };

            if (request.Task != null)
            {
                string taskFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Task.FileName);
                string taskFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Homeworks", taskFileName);

                try
                {
                    var homeworksDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Homeworks");
                    if (!Directory.Exists(homeworksDirectory))
                    {
                        Directory.CreateDirectory(homeworksDirectory);
                    }

                    using (var stream = new FileStream(taskFilePath, FileMode.Create))
                    {
                        await request.Task.CopyToAsync(stream);
                    }

                    homework.TaskPath = "/Homeworks/" + taskFileName;
                }
                catch
                {
                    return new ResponseModel
                    {
                        Message = "Error while uploading the task file",
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }
            }

            _context.Homeworks.Add(homework);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                Message = "Successfully created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
