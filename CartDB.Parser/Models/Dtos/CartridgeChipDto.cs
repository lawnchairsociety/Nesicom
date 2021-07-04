using System;

namespace CartDB.Parser.Models.Dtos
{
    public class CartridgeChipDto
    {
        public Guid Id { get; set; }
        public string PartNumber { get; set; }
        public Guid? ManufacturerId { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }
        public string Package { get; set; }
    }
}
