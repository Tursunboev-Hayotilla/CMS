using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CMS.Domain.Entities.Models
{
    public class CustomeTime
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
