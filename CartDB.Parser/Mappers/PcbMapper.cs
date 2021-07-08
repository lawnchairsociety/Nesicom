using System;
using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class PcbMapper
    {
        public static Pcb Map(PcbModel model, NesicomContext context)
        {
            // manufacturer
            var manufacturer = context.Manufacturers.FirstOrDefault(o => o.ManufacturerName == model.Manufacturer);
            if (manufacturer == null)
            {
                manufacturer = new Manufacturer
                {
                    ManufacturerName = model.Manufacturer,
                    Image = model.ManufacturerLogo
                };
            }

            // lifespan
            DateTime? lfStart = null;
            DateTime? lfEnd = null;

            if (!string.IsNullOrEmpty(model.LifeSpan))
            {
                var lfParts = model.LifeSpan.Split(" - ");
                lfStart = DateTime.Parse(lfParts[0]);

                if (lfParts.Length > 1)
                {
                    lfEnd = DateTime.Parse(lfParts[1]);
                }
            }

            // batteryPresent
            var bPresent = 0;

            switch (model.BatteryPresent)
            {
                case "Battery is not available":
                    bPresent = 1;
                    break;
                case "Battery is optional":
                    bPresent = 2;
                    break;
                case "Battery is present":
                    bPresent = 3;
                    break;
                default:
                    bPresent = 0;
                    break;
            }

            // mirroring
            var mirroring = 0;

            switch (model.Mirroring)
            {
                case "Uses vertical mirroring":
                    mirroring = 1;
                    break;
                case "Uses mapper controlled mirroring":
                    mirroring = 2;
                    break;
                case "Uses horizontal or vertical mirroring":
                    mirroring = 3;
                    break;
                case "Uses horizontal mirroring":
                    mirroring = 4;
                    break;
                case "Uses four screen mirroring":
                    mirroring = 5;
                    break;
                case "Uses one screen mirroring":
                    mirroring = 6;
                    break;
                default:
                    mirroring = 0;
                    break;
            }

            // images
            var images = model.PcbImages
                .Select(o => new Image { Filename = o })
                .ToList();

            return new Pcb
            {
                PcbName = model.PcbName,
                PcbNotes = model.PcbNotes,
                LifeSpanStart = lfStart,
                LifeSpanEnd = lfEnd,
                PcbClass = model.PcbClass,
                Mapper = model.Mapper,
                PrgRom = model.PRGRom,
                PrgRam = model.PRGRam,
                ChrRom = model.CHRRom,
                ChrRam = model.CHRRam,
                BatteryPresent = bPresent,
                Mirroring = mirroring,
                CIC = model.CIC,
                OtherChips = model.OtherChips,
                Images = images,
                Manufacturer = manufacturer
            };
        }
    }
}
