using System;

namespace CartDB.Parser.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CartClass { get; set; }
        public string CatalogEntry { get; set; }
        public string Players { get; set; }
        public string ReleaseDate { get; set; }
    }
}
