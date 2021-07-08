using System.Collections.Generic;
using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class CartridgeChipMapper
    {
        public static List<CartridgeChip> Map(List<CartridgeChipModel> model, NesicomContext context)
        {
            List<CartridgeChip> cartridgeChips = new List<CartridgeChip>();

            foreach(var modelCartridgeChip in model)
            {
                var cartridgeChip = context.CartridgeChips.FirstOrDefault(o => o.PartNumber == modelCartridgeChip.PartNumber);
                if(cartridgeChip == null)
                {
                    var manufacturer = context.Manufacturers.FirstOrDefault(o => o.ManufacturerName == modelCartridgeChip.Manufacturer);
                    if (manufacturer == null)
                    {
                        manufacturer = new Manufacturer
                        {
                            ManufacturerName = modelCartridgeChip.Manufacturer,
                            Image = modelCartridgeChip.ManufacturerImage
                        };
                    }

                    cartridgeChip = new CartridgeChip
                    {
                        PartNumber = modelCartridgeChip.PartNumber,
                        Designation = modelCartridgeChip.Designation,
                        Type = modelCartridgeChip.Type,
                        Package = modelCartridgeChip.Package,
                        Manufacturer = manufacturer
                    };
                }
            }

            return cartridgeChips;
        }
    }
}
