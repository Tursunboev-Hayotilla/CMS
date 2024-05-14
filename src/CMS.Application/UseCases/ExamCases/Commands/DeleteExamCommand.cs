using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamCases.Commands
{
    public class DeleteExamCommand:IRequest<ResponseModel>
    {
        public Guid ExamId { get; set; }
    }
}
