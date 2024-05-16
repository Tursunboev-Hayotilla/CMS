using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamAppraciate.Queries
{
    public class GetResultById:IRequest<ExamAppraciateStudent>
    {
        public Guid ExamId { get; set; }
    }
}
