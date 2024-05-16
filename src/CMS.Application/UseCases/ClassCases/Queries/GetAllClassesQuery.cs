using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ClassCases.Queries
{
    public class GetAllClassesQuery:IRequest<IEnumerable<Class>>
    {
    }
}
