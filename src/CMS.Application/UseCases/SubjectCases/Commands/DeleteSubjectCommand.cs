using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.SubjectCases.Commands
{
    public class DeleteSubjectCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
