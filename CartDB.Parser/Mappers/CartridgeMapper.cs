using System;
using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class CartridgeMapper
    {
        public static Cartridge Map(CartridgeModel model, NesicomSqlServerContext context)
        {
            //mfgstringpresent
            bool? stringPresent = null;
            switch(model.MfgStrPresent)
            {
                case "Yes":
                    stringPresent = true;
                    break;
                case "No":
                    stringPresent = false;
                    break;
                default:
                    stringPresent = null;
                    break;
            }

            // images
            var images = model.Images
                .Select(o => new Image { Filename = o })
                .ToList();

            // manufacturer
            var modelManufacturer = model.Producer;
            var manufacturer = context.Manufacturers.FirstOrDefault(o => o.ManufacturerName == modelManufacturer.Name);
            if (manufacturer == null)
            {
                manufacturer = ManufacturerMapper.Map(modelManufacturer, context);
            }

            // game
            var modelGame = model.Game;
            var game = context.Games.FirstOrDefault(o => o.GameName == modelGame.Name && o.CatalogEntry == modelGame.CatalogEntry);
            if (game == null)
            {
                game = GameMapper.Map(modelGame, context);
            }

            // pcb
            var pcb = context.Pcbs.FirstOrDefault(o => o.PcbName == model.Pcb);

            // cartridgechips
            var cartridgeChips = CartridgeChipMapper.Map(model.CartridgeChips, context);

            return new Cartridge
            {
                Color = model.Color,
                FormFactor = model.FormFactor,
                EmbossedText = model.EmbossedText,
                FrontLabelEntry = model.FrontLabelEntry,
                SealOfQuality = model.SealOfQuality,
                MfgStrPresent = stringPresent,
                BackLabelEntry = model.BackLabelEntry,
                TwoDigitCode = model.TwoDigitCode,
                Revision = model.Revision,
                CICType = model.CICType,
                Hardware = model.Hardware,
                WRAM = model.WRAM,
                VRAM = model.VRAM,
                Images = images,
                Manufacturer = manufacturer,
                Game = game,
                Pcb = pcb,
                CartridgeChips = cartridgeChips
            };
        }
    }
}
