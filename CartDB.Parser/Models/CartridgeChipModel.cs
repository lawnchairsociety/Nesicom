namespace CartDB.Parser.Models
{
    public class CartridgeChipModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string PartNumber { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerLogo { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }
        public string Package { get; set; }
    }
}
