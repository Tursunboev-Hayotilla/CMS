using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ClassCases.Commands
{
    public class DeleteClassCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
