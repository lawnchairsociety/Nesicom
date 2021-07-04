using System;

namespace CartDB.Parser.Models.Dtos
{
    public class ManufacturerImageDto
    {
        public Guid Id { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid ImageId { get; set; }
    }
}
