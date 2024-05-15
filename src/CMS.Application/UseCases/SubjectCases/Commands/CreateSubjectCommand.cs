using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.SubjectCases.Commands
{
    public class CreateSubjectCommand:IRequest<ResponseModel>
    {
        public string Name { get; set; }
    }
}
