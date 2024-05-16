using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamAppraciate.Queries
{
    public class GetAllExamResultsByClassId:IRequest<List<ExamAppraciateStudent>>
    {
        public Guid ClassId { get; set; }
    }
}
