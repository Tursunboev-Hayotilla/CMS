using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Commands
{
    public class CreateHomeworkCommand : IRequest<ResponseModel>
    {
        public string TZ { get; set; }
        public Guid LessonId { get; set; }
        public IFormFile Task { get; set; }
    }
}
