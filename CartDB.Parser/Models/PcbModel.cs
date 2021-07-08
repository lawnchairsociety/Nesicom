using System.Collections.Generic;

namespace CartDB.Parser.Models
{
    public class PcbModel
    {
        public string Manufacturer { get; set; }
        public string ManufacturerLogo { get; set; }
        public string PcbName { get; set; }
        public string PcbNotes { get; set; }
        public List<string> PcbImages { get; set; }
        public string LifeSpan { get; set; }
        public string PcbClass { get; set; }
        public string Mapper { get; set; }
        public string PRGRom { get; set; }
        public string PRGRam { get; set; }
        public string CHRRom { get; set; }
        public string CHRRam { get; set; }
        public string BatteryPresent { get; set; }
        public string Mirroring { get; set; }
        public string CIC { get; set; }
        public string OtherChips { get; set; }
    }

    public class PcbListModel
    {
        public List<PcbModel> Pcbs { get; set; }
    }
}
