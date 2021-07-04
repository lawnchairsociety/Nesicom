using System;
using System.Collections.Generic;

namespace CartDB.API.Models
{
    public class CartridgeDto
    {
        public Guid Id { get; set; }
        public GameDto Game { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
        public PcbDto Pcb { get; set; }
        public List<CartridgeChipDto> CartridgeChips { get; set; }
        public List<ImageDto> Images { get; set; }
        public string Color { get; set; }
        public string FormFactor { get; set; }
        public string EmbossedText { get; set; }
        public string FrontLabelEntry { get; set; }
        public string SealOfQuality { get; set; }
        public bool MfgStringPresent { get; set; }
        public string BackLabelEntry { get; set; }
        public string TwoDigitCode { get; set; }
        public string Revision { get; set; }
        public string CICType { get; set; }
        public string Hardware { get; set; }
        public string WRAM { get; set; }
        public string VRAM { get; set; }
    }
}
