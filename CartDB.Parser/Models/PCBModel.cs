using System;
using System.Collections.Generic;

namespace CartDB.Parser.Models
{
    public class PCBModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerLogo { get; set; }
        public string PCBName { get; set; }
        public string PCBNotes { get; set; }
        public List<string> PCBImages { get; set; }
        public string LifeSpan { get; set; }
        public string PCBClass { get; set; }
        public string Mapper { get; set; }
        public string PrgRom { get; set; }
        public string PrgRam { get; set; }
        public string ChrRom { get; set; }
        public string ChrRam { get; set; }
        public string BatteryPresent { get; set; }
        public string Mirroring { get; set; }
        public string CIC { get; set; }
        public List<string> OtherChips { get; set; }
    }
}
