using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class CartridgeCartridgeChip
    {
        [Key]
        public Guid CartridgeCartridgeChipId { get; set; }
        public Guid CartridgeId { get; set; }
        public Guid CartridgeChipId { get; set; }

        [ForeignKey(nameof(CartridgeId))]
        [InverseProperty("CartridgeCartridgeChips")]
        public virtual Cartridge Cartridge { get; set; }
        [ForeignKey(nameof(CartridgeChipId))]
        [InverseProperty("CartridgeCartridgeChips")]
        public virtual CartridgeChip CartridgeChip { get; set; }
    }
}
