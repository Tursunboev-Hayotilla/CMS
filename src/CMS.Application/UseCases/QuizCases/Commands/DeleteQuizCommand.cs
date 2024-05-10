using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.QuizCases.Commands
{
    public class DeleteQuizCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
