using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class CartridgeChip
    {
        public CartridgeChip()
        {
            CartridgeCartridgeChips = new HashSet<CartridgeCartridgeChip>();
        }

        [Key]
        public Guid CartridgeChipId { get; set; }
        [Required]
        public string PartNumber { get; set; }
        public Guid? ManufacturerId { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }
        public string Package { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty("CartridgeChips")]
        public virtual Manufacturer Manufacturer { get; set; }
        [InverseProperty(nameof(CartridgeCartridgeChip.CartridgeChip))]
        public virtual ICollection<CartridgeCartridgeChip> CartridgeCartridgeChips { get; set; }
    }
}
