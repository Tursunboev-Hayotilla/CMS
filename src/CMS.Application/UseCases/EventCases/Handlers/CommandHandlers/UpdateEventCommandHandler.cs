using CMS.Application.Abstractions;
using CMS.Application.UseCases.EventCases.Commands;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Handlers.CommandHandlers
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ResponseModel>
    {
        private readonly ICMSDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateEventCommandHandler(ICMSDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var existingEvent = await _context.Events.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (existingEvent == null)
            {
                return new ResponseModel
                {
                    Message = "Event not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            existingEvent.Title = request.Title;
            existingEvent.Date = request.Date;
            existingEvent.Description = request.Description;

            if (request.Photo != null)
            {
                if (!string.IsNullOrEmpty(existingEvent.PhotoPath))
                {
                    var oldPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, existingEvent.PhotoPath.TrimStart('/'));
                    if (File.Exists(oldPhotoPath))
                    {
                        File.Delete(oldPhotoPath);
                    }
                }

                var newPhotoName = Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
                var newPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "Events", newPhotoName);

                using (var stream = new FileStream(newPhotoPath, FileMode.Create))
                {
                    await request.Photo.CopyToAsync(stream);
                }

                existingEvent.PhotoPath = "/Events/" + newPhotoName;
            }

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return new ResponseModel
                {
                    Message = "Event updated successfully",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseModel
                {
                    Message = "Error updating event",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}
