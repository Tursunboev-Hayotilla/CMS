using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Commands
{
    public class DeleteHomework : IRequest<ResponseModel>
    {
        public Guid HomeworkId { get; set; }
    }
}
