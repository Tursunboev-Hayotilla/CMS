using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string photoName = "";
            string photoPath = "";

            try
            {
                photoName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                photoPath = Path.Combine(_webHostEnvironment.WebRootPath, "Events", photoName);

                using (var stream = new FileStream(photoPath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
            }
            catch 
            {
                return new ResponseModel()
                {
                    Message = "Error while apploading the photo",
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
            var res = await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Succesfully created",
                StatusCode = 203,
                IsSuccess = true,
            };
        }
    }
}
