using System;
using System.Collections.Generic;

namespace CartDB.Parser.TransientModels
{
    public class TransientCartridgeChipModel
    {
        public int Id { get; set; }
        public Guid Nid { get; set; }
        public int CartId { get; set; }
        public Guid CartridgeId { get; set; }
        public string PartNumber { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerImage { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }
        public string Package { get; set; }
    }

    public class TransientCartridgeChipListModel
    {
        public List<TransientCartridgeChipModel> CartridgeChips { get; set; }
    }
}
