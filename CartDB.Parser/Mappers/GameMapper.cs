using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public static class GameMapper
    {
        public static List<Game> MapData(List<TransientGameModel> games, List<Publisher> publishers,
            List<Developer> developers, List<Region> regions)
        {
            var result = new List<Game>();

            foreach (var game in games)
            {
                var newGame = new Game
                {
                    GameId = game.Nid,
                    GameName = game.Name,
                    Class = game.CartClass,
                    CatalogEntry = game.CatalogEntry,
                    PublisherId = null,
                    DeveloperId = null,
                    RegionId = null,
                    Players = null,
                    ReleaseDate = null,
                    Peripherals = game.Peripherals,
                    PeripheralsImage = game.Peripherals
                };

                if (publishers.Where(p => p.PublisherName == game.Publisher).Count() != 0)
                {
                    newGame.PublisherId = publishers.Where(p => p.PublisherName == game.Publisher).FirstOrDefault().PublisherId;
                }

                if (developers.Where(d => d.DeveloperName == game.Developer).Count() != 0)
                {
                    newGame.DeveloperId = developers.Where(d => d.DeveloperName == game.Developer).FirstOrDefault().DeveloperId;
                }

                if (regions.Where(r => r.RegionName == game.Region).Count() != 0)
                {
                    newGame.RegionId = regions.Where(r => r.RegionName == game.Region).FirstOrDefault().RegionId;
                }
                
                if (DateTime.TryParse(game.ReleaseDate, out DateTime releaseDate))
                {
                    newGame.ReleaseDate = releaseDate;
                }

                if (Int32.TryParse(game.Players, out int playerCount))
                {
                    newGame.Players = playerCount;
                }

                result.Add(newGame);
            }

            return result;
        }
    }
}
