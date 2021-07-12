using System;
using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class GameMapper
    {
        public static Game Map(GameModel model, NesicomSqlServerContext context)
        {
            // region
            var regionModel = model.Region;
            var region = context.Regions.FirstOrDefault(o => o.RegionName == regionModel.Name);
            if (region == null)
            {
                region = RegionMapper.Map(regionModel, context);
            }

            // publisher
            var publisherModel = model.Publisher;
            var publisher = context.Publishers.FirstOrDefault(o => o.PublisherName == publisherModel.Name);
            if (publisher == null)
            {
                publisher = PublisherMapper.Map(publisherModel, context);
            }

            // developer
            var developerModel = model.Developer;
            var developer = context.Developers.FirstOrDefault(o => o.DeveloperName == developerModel.Name);
            if (developer == null)
            {
                developer = DeveloperMapper.Map(developerModel, context);
            }

            // players
            int? players = null;
            if(int.TryParse(model.Players, out int tempPlayers))
            {
                players = tempPlayers;
            }

            // releasedate
            DateTime? releaseDate = null;
            if(DateTime.TryParse(model.ReleaseDate, out DateTime tempReleaseDate))
            {
                releaseDate = tempReleaseDate;
            }

            return new Game
            {
                GameName = model.Name,
                Class = model.CartClass,
                CatalogEntry = model.CatalogEntry,
                Players = players,
                ReleaseDate = releaseDate,
                Peripherals = model.Peripherals,
                PeripheralsImage = model.PeripheralsImage,
                Publisher = publisher,
                Developer = developer,
                Region = region
            };
        }
    }
}
