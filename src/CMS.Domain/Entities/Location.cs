namespace CMS.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public required string Country { get; set; }
        public required string Region { get; set; }
        public required string District { get; set; }
        public string? HomeNumber { get; set; }
        public long? Latitude { get; set; }
        public long? Longitude { get; set; }

    }
}
