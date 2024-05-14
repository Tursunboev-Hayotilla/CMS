using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Queries
{
    public class GetEventByDateQuery:IRequest<Event>
    {
        public int Day { get; set; }
        public int Month { get; set; }
    }
}
