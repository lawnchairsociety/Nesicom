using System.Collections.Generic;

namespace CartDB.API.Models
{
    public class SearchDto
    {
        public List<CartridgeChipDto> CartridgeChips { get; set; }
        public List<CartridgeDto> Cartridges { get; set; }
        public List<DeveloperDto> Developers { get; set; }
        public List<GameDto> Games { get; set; }
        public List<ManufacturerDto> Manufacturers { get; set; }
        public List<PcbDto> Pcbs { get; set; }
        public List<PublisherDto> Publishers { get; set; }
        public List<RegionDto> Regions { get; set; }
    }
}
