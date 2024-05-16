using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.Auth.ForgotPasswordCases
{
    public class ForgotPasswordCommand:IRequest<ResponseModel>
    {
        public string Email { get; set; }
    }
}
