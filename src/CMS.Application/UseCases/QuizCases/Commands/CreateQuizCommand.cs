using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Commands
{
    public class CreateQuizCommand:IRequest<ResponseModel>
    {
        public string Question {  get; set; }
        public string OptionsA { get; set; }
        public string OptionsB { get; set; }
        public string OptionsC { get; set; }
        public string? OptionsD { get; set; }
        public char CorrectAnswer { get; set; }
        public IFormFile? DescriptionPhoto { get; set; }
        public Guid? LessonId { get; set; }
        public Guid? SubjectId { get; set; }
    }
}
