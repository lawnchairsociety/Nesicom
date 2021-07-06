using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public class CartridgeChipMapper
    {
        // cartridgechips (DROP IF PARTNUMBER EMPTY)
        public static List<CartridgeChip> MapData(List<TransientCartridgeChipModel> cartridgeChips,
            List<Manufacturer> manufacturers)
        {
            var result = new List<CartridgeChip>();

            foreach (var cartridgeChip in cartridgeChips)
            {
                if (!string.IsNullOrEmpty(cartridgeChip.PartNumber))
                {
                    var cartChip = new CartridgeChip
                    {
                        CartridgeChipId = cartridgeChip.Nid,
                        PartNumber = cartridgeChip.PartNumber,
                        Designation = cartridgeChip.Designation,
                        Type = cartridgeChip.Type,
                        Package = cartridgeChip.Package,
                        CartridgeId = cartridgeChip.CartridgeId,
                        ManufacturerId = manufacturers.Where(m => m.ManufacturerName == cartridgeChip.Manufacturer).Select(m => m.ManufacturerId).FirstOrDefault()
                    };

                    result.Add(cartChip);
                }
            }

            return result;
        }
    }
}
