using System;

namespace CartDB.API.Models
{
    public class CartridgeChipDto
    {
        public Guid Id { get; set; }
        public string PartNumber { get; set; }
        public ManufacturerDto? Manufacturer { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }
        public string Package { get; set; }
    }
}
