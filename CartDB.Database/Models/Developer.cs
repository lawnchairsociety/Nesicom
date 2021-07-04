using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class Developer
    {
        public Developer()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        public Guid DeveloperId { get; set; }
        [Required]
        public string DeveloperName { get; set; }

        [InverseProperty(nameof(Game.Developer))]
        public virtual ICollection<Game> Games { get; set; }
    }
}
