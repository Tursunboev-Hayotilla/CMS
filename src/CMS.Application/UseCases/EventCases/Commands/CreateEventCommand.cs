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
    public class CreateEventCommand:IRequest<ResponseModel>
    {
        public string Title { get; set; }
        public CustomeDate Date {  get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
      
    }
}
