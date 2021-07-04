using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class Game
    {
        [Key]
        public Guid GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public string Class { get; set; }
        public string CatalogEntry { get; set; }
        public Guid? PublisherId { get; set; }
        public Guid? DeveloperId { get; set; }
        public Guid? RegionId { get; set; }
        public int? Players { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }

        [ForeignKey(nameof(DeveloperId))]
        [InverseProperty("Games")]
        public virtual Developer Developer { get; set; }
        [ForeignKey(nameof(PublisherId))]
        [InverseProperty("Games")]
        public virtual Publisher Publisher { get; set; }
        [ForeignKey(nameof(RegionId))]
        [InverseProperty("Games")]
        public virtual Region Region { get; set; }
    }
}
