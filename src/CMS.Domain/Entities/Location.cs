using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Location
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required string Country { get; set; }
        public required string Region { get; set; }
        public required string District { get; set; }
        public string? HomeNumber { get; set; }

        // Menimcha buni bizga keragi yo'q
       /* public long? Latitude { get; set; }
        public long? Longitude { get; set; }
*/
    }
}
