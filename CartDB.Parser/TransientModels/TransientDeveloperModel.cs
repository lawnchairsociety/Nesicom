using System;
using System.Collections.Generic;

namespace CartDB.Parser.TransientModels
{
    public class TransientDeveloperModel
    {
        public int Id { get; set; }
        public Guid Nid { get; set; }
        public Guid CartridgeId { get; set; }
        public string Name { get; set; }
    }

    public class TransientDeveloperListModel
    {
        public List<TransientDeveloperModel> Developers { get; set; }
    }
}
