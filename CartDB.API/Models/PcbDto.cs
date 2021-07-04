using System;
using System.Collections.Generic;

namespace CartDB.API.Models
{
    public class PcbDto
    {
        public Guid Id { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<ImageDto> Images { get; set; }
        public DateTime? LifeSpanStart { get; set; }
        public DateTime? LifeSpanEnd { get; set; }
        public string Class { get; set; }
        public string Mapper { get; set; }
        public string PrgRom { get; set; }
        public string PrgRam { get; set; }
        public string ChrRom { get; set; }
        public string ChrRam { get; set; }
        public BatteryPresentType BatteryPresent { get; set; }
        public MirroringType Mirroring { get; set; }
        public string CIC { get; set; }
    }
}
