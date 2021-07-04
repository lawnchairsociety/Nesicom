using System;

namespace CartDB.Parser.Models.Dtos
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string CatalogEntry { get; set; }
        public Guid? PublisherId { get; set; }
        public Guid? DeveloperId { get; set; }
        public Guid? RegionId { get; set; }
        public int? Players { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
