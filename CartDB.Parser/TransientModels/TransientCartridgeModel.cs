using System;
using System.Collections.Generic;

namespace CartDB.Parser.TransientModels
{
    public class TransientCartridgeModel
    {
        public int Id { get; set; }
        public Guid Nid { get; set; }
        public string Color { get; set; }
        public string FormFactor { get; set; }
        public string EmbossedText { get; set; }
        public string FrontLabelEntry { get; set; }
        public string SealOfQuality { get; set; }
        public string MfgStrPresent { get; set; }
        public string BackLabelEntry { get; set; }
        public string TwoDigitCode { get; set; }
        public string Revision { get; set; }
        public string Pcb { get; set; }
        public string CICType { get; set; }
        public string Hardware { get; set; }
        public string WRAM { get; set; }
        public string VRAM { get; set; }
        public List<string> Images { get; set; }
    }

    public class TransientCartridgeListModel
    {
        public List<TransientCartridgeModel> Cartridges { get; set; }
    }
}
