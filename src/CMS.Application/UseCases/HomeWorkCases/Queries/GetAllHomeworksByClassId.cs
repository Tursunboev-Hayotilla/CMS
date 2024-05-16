using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.HomeWorkCases.Queries
{
    public class GetAllHomeworksByClassId:IRequest<IEnumerable<Homework>>
    {
        public Guid ClassId { get; set; }
    }
}
