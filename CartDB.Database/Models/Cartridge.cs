using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class Cartridge
    {
        public Cartridge()
        {
            CartridgeCartridgeChips = new HashSet<CartridgeCartridgeChip>();
            CartridgeImages = new HashSet<CartridgeImage>();
        }

        [Key]
        public Guid CartridgeId { get; set; }
        public Guid? ManufacturerId { get; set; }
        public string Color { get; set; }
        public string FormFactor { get; set; }
        public string EmbossedText { get; set; }
        public string FrontLabelEntry { get; set; }
        public string SealOfQuality { get; set; }
        public bool? MfgStrPresent { get; set; }
        public string BackLabelEntry { get; set; }
        public string TwoDigitCode { get; set; }
        public string Revision { get; set; }
        public Guid? PcbId { get; set; }
        [Column("CICType")]
        public string Cictype { get; set; }
        public string Hardware { get; set; }
        [Column("WRAM")]
        public string Wram { get; set; }
        [Column("VRAM")]
        public string Vram { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty("Cartridges")]
        public virtual Manufacturer Manufacturer { get; set; }
        [ForeignKey(nameof(PcbId))]
        [InverseProperty("Cartridges")]
        public virtual Pcb Pcb { get; set; }
        [InverseProperty(nameof(CartridgeCartridgeChip.Cartridge))]
        public virtual ICollection<CartridgeCartridgeChip> CartridgeCartridgeChips { get; set; }
        [InverseProperty(nameof(CartridgeImage.Cartridge))]
        public virtual ICollection<CartridgeImage> CartridgeImages { get; set; }
    }
}
