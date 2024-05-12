using CMS.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.Auth
{
    public interface IAuthServise
    {
        public Task<string> GenerateToken(User user);
    }
}
