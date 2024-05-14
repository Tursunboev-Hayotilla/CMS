using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamCases.Commands
{
    public class CreateExamCommand:IRequest<ResponseModel>
    {
        public required string Task { get; set; }
        public int Coin { get; set; }
        public CustomeDate Date { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? ClassId { get; set; }
    }
}