using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ClassCases.Queries
{
    public class GetClassByIdQuery:IRequest<Class>
    {
        public Guid Id { get; set; }
    }
}
