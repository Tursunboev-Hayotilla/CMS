using CMS.Application.Abstractions;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EventCases.Commands
{
    public class DeleteEventCommand:IRequest<ResponseModel>
    {
        public Guid EventId {  get; set; }   
    }
}
