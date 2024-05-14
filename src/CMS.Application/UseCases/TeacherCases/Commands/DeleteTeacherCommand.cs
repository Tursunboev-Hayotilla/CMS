using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.TeacherCases.Commands
{
    public class DeleteTeacherCommand : IRequest<ResponseModel>
    {
        public string Id { get; set; }
    }
}
