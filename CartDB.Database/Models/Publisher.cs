using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        public Guid PublisherId { get; set; }
        [Required]
        public string PublisherName { get; set; }

        [InverseProperty(nameof(Game.Publisher))]
        public virtual ICollection<Game> Games { get; set; }
    }
}
