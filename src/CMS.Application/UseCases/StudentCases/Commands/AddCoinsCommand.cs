using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.StudentCases.Commands
{
    public class AddCoinsCommand:IRequest<ResponseModel>
    {
        public string Id { get; set; }
        public int Coin {  get; set; }
    }
}
