using System;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Game
    {
#nullable enable
        [Key]
        public Guid GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public string? Class { get; set; }
        public string? CatalogEntry { get; set; }
        public Guid? PublisherId { get; set; }
        public Guid? DeveloperId { get; set; }
        public Guid? RegionId { get; set; }
        public int? Players { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Peripherals { get; set; }
        public string? PeripheralsImage { get; set; }
#nullable disable

        public Publisher Publisher { get; set; }
        public Developer Developer { get; set; }
        public Region Region { get; set; }
    }
}
