using System;

namespace CartDB.Parser.Models.Dtos
{
    public class CartridgeCartridgeChipDto
    {
        public Guid Id { get; set; }
        public Guid CartridgeId { get; set; }
        public Guid CartridgeChipId { get; set; }
    }
}
