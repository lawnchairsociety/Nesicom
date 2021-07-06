using System;
using System.Collections.Generic;

namespace CartDB.Parser.TransientModels
{
    public class TransientRegionModel
    {
        public int Id { get; set; }
        public Guid Nid { get; set; }
        public Guid CartridgeId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class TransientRegionsListModel
    {
        public List<TransientRegionModel> Regions { get; set; }
    }
}
