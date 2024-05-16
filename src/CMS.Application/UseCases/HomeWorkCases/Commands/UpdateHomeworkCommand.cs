using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Commands
{
    public class UpdateHomeworkCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string TZ { get; set; }
        public int Coin { get; set; }
        public Guid LessonId { get; set; }
    }
}
