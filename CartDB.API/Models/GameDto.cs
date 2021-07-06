using System;

namespace CartDB.API.Models
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public PublisherDto Publisher { get; set; }
        public DeveloperDto Developer { get; set; }
        public RegionDto Region { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string CatalogEntry { get; set; }
        public int? Players { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Peripherals { get; set; }
        public string PeripheralsImage { get; set; }
    }
}
