using System;

namespace CartDB.Parser.Models.Dtos
{
    public class CartridgeImageDto
    {
        public Guid Id { get; set; }
        public Guid CartridgeId { get; set; }
        public Guid ImageId { get; set; }
    }
}
