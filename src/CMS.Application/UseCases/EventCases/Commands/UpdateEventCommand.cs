using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Commands
{
    public class UpdateEventCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public virtual CustomeDate Date { get; set; }
        public required string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}