using System;

namespace CartDB.Parser.Models.Dtos
{
    public class PcbImageDto
    {
        public Guid Id { get; set; }
        public Guid PcbId { get; set; }
        public Guid ImageId { get; set; }
    }
}
