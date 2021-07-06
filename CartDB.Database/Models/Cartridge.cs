using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Cartridge
    {
#nullable enable
        [Key]
        public Guid CartridgeId { get; set; }
        public Guid? MfgId { get; set; }
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

        public ICollection<Image> Images { get; set; }
        public Game Game { get; set; }
        public Pcb Pcb { get; set; }
    }
}
