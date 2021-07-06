using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public class CartridgeMapper
    {
        // (SPLIT THE HARDWARE TYPES INTO SEPARATE TABLE)
        // (CREATE ENUM FOR MFGSTRPRESENT)
        // (CREATE ENUM FOR CICTYPE)
        public static List<Cartridge> MapData(List<TransientCartridgeModel> cartridges, List<TransientProducerModel> producers,
            List<TransientGameModel> games, List<Image> images)
        {
            var result = new List<Cartridge>();

            foreach (var cartridge in cartridges)
            {
                var newCartridge = new Cartridge
                {
                    CartridgeId = cartridge.Nid,
                    ManufacturerId = producers.Where(p => p.CartridgeId == cartridge.Nid).Select(p => p.Nid).FirstOrDefault(),
                    GameId = games.Where(g => g.CartridgeId == cartridge.Nid).Select(g => g.Nid).FirstOrDefault(),
                    Color = cartridge.Color,
                    FormFactor = cartridge.FormFactor,
                    EmbossedText = cartridge.EmbossedText,
                    FrontLabelEntry = cartridge.FrontLabelEntry,
                    SealOfQuality = cartridge.SealOfQuality,
                    BackLabelEntry = cartridge.BackLabelEntry,
                    TwoDigitCode = cartridge.TwoDigitCode,
                    Revision = cartridge.Revision,
                    CICType = cartridge.CICType,
                    Hardware = cartridge.Hardware,
                    WRAM = cartridge.WRAM,
                    VRAM = cartridge.VRAM,
                    Images = images.Where(i=> i.CartridgeId == cartridge.Nid).ToList()
                };

                switch(cartridge.MfgStrPresent)
                {
                    case "Yes":
                        newCartridge.MfgStrPresent = true;
                        break;
                    case "No":
                        newCartridge.MfgStrPresent = false;
                        break;
                    default:
                        newCartridge.MfgStrPresent = null;
                        break;
                }

                result.Add(newCartridge);


            }

            return result;
        }
    }
}
