using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StundentAppraciateCases.Commands
{
    public class UpdateStudentAppraciateCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string studentId { get; set; }
        public Guid LessonId { get; set; }
        public byte? LessonCoin { get; set; }
        public byte? HomeworkCoin { get; set; }
    }
}
