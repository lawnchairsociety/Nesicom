using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class GameModelToDtoMapper : AbstractModelToDtoMapper<Game, GameDto>
    {
        public override GameDto MapDto(Game model)
        {
            PublisherModelToDtoMapper publisherMapper = new PublisherModelToDtoMapper();
            DeveloperModelToDtoMapper developerMapper = new DeveloperModelToDtoMapper();
            RegionModelToDtoMapper regionMapper = new RegionModelToDtoMapper();

            if (model == null)
            {
                return null;
            }

            return new GameDto
            {
                Id = model.GameId,
                Publisher = publisherMapper.MapDto(model.Publisher),
                Developer = developerMapper.MapDto(model.Developer),
                Region = regionMapper.MapDto(model.Region),
                Name = model.GameName,
                Class = model.Class,
                CatalogEntry = model.CatalogEntry,
                Players = model.Players,
                ReleaseDate = model.ReleaseDate,
                Peripherals = model.Peripherals,
                PeripheralsImage = model.PeripheralsImage
            };
        }
    }
}
