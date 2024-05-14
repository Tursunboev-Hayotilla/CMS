using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamCases.Queries
{
    public class GetExamByIdQuery:IRequest<Examine>
    {
        public Guid ExamId { get; set; }
    }
}
