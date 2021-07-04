using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class Region
    {
        public Region()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        public Guid RegionId { get; set; }
        [Required]
        public string RegionName { get; set; }

        [InverseProperty(nameof(Game.Region))]
        public virtual ICollection<Game> Games { get; set; }
    }
}
