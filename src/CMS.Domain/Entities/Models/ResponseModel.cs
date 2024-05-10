using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }=false;
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
