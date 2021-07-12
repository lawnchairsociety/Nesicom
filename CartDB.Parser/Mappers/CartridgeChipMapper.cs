using System.Collections.Generic;
using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class CartridgeChipMapper
    {
        public static List<CartridgeChip> Map(List<CartridgeChipModel> model, NesicomSqlServerContext context)
        {
            List<CartridgeChip> cartridgeChips = new List<CartridgeChip>();

            foreach (var modelCartridgeChip in model)
            {
                if (string.IsNullOrWhiteSpace(modelCartridgeChip.PartNumber))
                {
                    continue;
                }

                var manufacturer = context.Manufacturers.FirstOrDefault(o => o.ManufacturerName == modelCartridgeChip.Manufacturer);
                if (manufacturer == null)
                {
                    manufacturer = new Manufacturer
                    {
                        ManufacturerName = modelCartridgeChip.Manufacturer,
                        Image = modelCartridgeChip.ManufacturerImage
                    };
                }

                var cartridgeChip = new CartridgeChip
                {
                    PartNumber = modelCartridgeChip.PartNumber,
                    Designation = modelCartridgeChip.Designation,
                    Type = modelCartridgeChip.Type,
                    Package = modelCartridgeChip.Package,
                    Manufacturer = manufacturer
                };

                cartridgeChips.Add(cartridgeChip);
            }

            return cartridgeChips;
        }
    }
}
