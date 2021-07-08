namespace CartDB.Parser.Models
{
    public class GameModel
    {
        public string Name { get; set; }
        public string CartClass { get; set; }
        public string CatalogEntry { get; set; }
        public string Players { get; set; }
        public string ReleaseDate { get; set; }
        public string Peripherals { get; set; }
        public string PeripheralsImage { get; set; }
        public DeveloperModel Developer { get; set; }
        public PublisherModel Publisher { get; set; }
        public RegionModel Region { get; set; }
    }
}
