using System;
using System.Collections.Generic;

namespace CartDB.Parser.TransientModels
{
    public class TransientPublisherModel
    {
        public int Id { get; set; }
        public Guid Nid { get; set; }
        public Guid CartridgeId { get; set; }
        public string Name { get; set; }
    }

    public class TransientPublisherListModel
    {
        public List<TransientPublisherModel> Publishers { get; set; }
    }
}
