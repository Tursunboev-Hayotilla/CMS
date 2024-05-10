using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Commands
{
    public class UpdateQuizCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public required string Question { get; set; }
        public required string Options1 { get; set; }
        public required string Options2 { get; set; }
        public required string Options3 { get; set; }
        public string? Options4 { get; set; }
        public required string CorrectAnswear { get; set; }
        public string? DescriptionPhotoPath { get; set; }
        public virtual Lesson LessonId { get; set; }
        public virtual Subject SubjectId { get; set; }
    }
}
