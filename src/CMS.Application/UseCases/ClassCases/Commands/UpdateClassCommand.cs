using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ClassCases.Commands
{
    public class UpdateClassCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Grade { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
