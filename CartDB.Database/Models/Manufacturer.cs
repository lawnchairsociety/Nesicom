using System;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Manufacturer
    {
#nullable enable
        [Key]
        public Guid ManufacturerId { get; set; }
        [Required]
        public string ManufacturerName { get; set; }
        public string? Image { get; set; }
#nullable disable
    }
}
