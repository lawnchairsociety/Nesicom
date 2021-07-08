using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Cartridge
    {
        public Cartridge()
        {
            Images = new HashSet<Image>();
            CartridgeChips = new HashSet<CartridgeChip>();
        }

#nullable enable
        [Key]
        public Guid CartridgeId { get; set; }
        public Guid? ManufacturerId { get; set; }
        public Guid? GameId { get; set; }
        public string? Color { get; set; }
        public string? FormFactor { get; set; }
        public string? EmbossedText { get; set; }
        public string? FrontLabelEntry { get; set; }
        public string? SealOfQuality { get; set; }
        public bool? MfgStrPresent { get; set; }
        public string? BackLabelEntry { get; set; }
        public string? TwoDigitCode { get; set; }
        public string? Revision { get; set; }
        public Guid? PcbId { get; set; }
        public string? CICType { get; set; }
        public string? Hardware { get; set; }
        public string? WRAM { get; set; }
        public string? VRAM { get; set; }
#nullable disable

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<CartridgeChip> CartridgeChips { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Game Game { get; set; }
        public virtual Pcb Pcb { get; set; }
    }
}
