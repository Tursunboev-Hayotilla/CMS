using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Handlers.CommandHandlers
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateEventCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var photo = request.Image;
            string photoName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            string photoPath = Path.Combine(_webHostEnvironment.WebRootPath, "Events", photoName);

            try
            {
                var eventsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Events");
                if (!Directory.Exists(eventsDirectory))
                {
                    Directory.CreateDirectory(eventsDirectory);
                }

                using (var stream = new FileStream(photoPath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
            }
            catch
            {
                return new ResponseModel()
                {
                    Message = "Error while uploading the photo",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            var newEvent = new Event()
            {
                Title = request.Title,
                Date = request.Date,
                Description = request.Description,
                PhotoPath = "/Events/" + photoName
            };

            await _context.Events.AddAsync(newEvent, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                Message = "Successfully created",
                StatusCode = 201,
                IsSuccess = true,
            };
        }
    }
}
