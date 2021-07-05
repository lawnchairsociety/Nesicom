using System;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Region
    {
        [Key]
        public Guid RegionId { get; set; }
        [Required]
        public string RegionName { get; set; }
        public string Image { get; set; }
    }
}
