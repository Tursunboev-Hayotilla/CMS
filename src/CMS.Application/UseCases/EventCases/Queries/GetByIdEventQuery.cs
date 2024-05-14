using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Queries
{
    public class GetByIdEventQuery:IRequest<Event>
    {
        public Guid Id { get; set; }
    }
}
