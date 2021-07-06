using System;
using System.Collections.Generic;

namespace CartDB.Parser.TransientModels
{
    public class TransientGameModel
    {
        public int Id { get; set; }
        public Guid Nid { get; set; }
        public Guid CartridgeId { get; set; }
        public Guid RegionId { get; set; }
        public string Region { get; set; }
        public Guid? PublisherId { get; set; }
        public string Publisher { get; set; }
        public Guid? DeveloperId { get; set; }
        public string Developer { get; set; }
        public string Name { get; set; }
        public string CartClass { get; set; }
        public string CatalogEntry { get; set; }
        public string Players { get; set; }
        public string ReleaseDate { get; set; }
        public string Peripherals { get; set; }
        public string PeripheralsImage { get; set; }
    }

    public class TransientGameListModel
    {
        public List<TransientGameModel> Games { get; set; }
    }
}
