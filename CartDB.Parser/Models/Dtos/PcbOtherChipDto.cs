using System;

namespace CartDB.Parser.Models.Dtos
{
    public class PcbOtherChipDto
    {
        public Guid Id { get; set; }
        public Guid PcbId { get; set; }
        public Guid OtherChipId { get; set; }
    }
}
