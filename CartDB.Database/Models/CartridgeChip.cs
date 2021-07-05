using System;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class CartridgeChip
    {
#nullable enable
        [Key]
        public Guid CartridgeChipId { get; set; }
        [Required]
        public string PartNumber { get; set; }
        public Guid? ManufacturerId { get; set; }
        public Guid? CartridgeId { get; set; }
        public string? Designation { get; set; }
        public string? Type { get; set; }
        public string? Package { get; set; }
#nullable disable

        public Cartridge Cartridge { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
