using System;
using System.Collections.Generic;
using System.Linq;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public static class ImageMapper
    {
        public static List<Image> MapData(List<TransientPcbModel> pcbs, List<TransientCartridgeModel> cartridges)
        {
            var result = new List<Image>();

            foreach (var pcb in pcbs)
            {
                foreach (var img in pcb.PcbImages)
                {
                    var newId = Guid.NewGuid();
                    while (result.Where(i => i.ImageId == newId).Count() != 0)
                    {
                        newId = Guid.NewGuid();
                    }

                    result.Add(new Image
                    {
                        ImageId = newId,
                        Filename = img,
                        PcbId = pcb.Nid
                    });
                }
            }

            foreach (var cart in cartridges)
            {
                foreach (var img in cart.Images)
                {
                    var newId = Guid.NewGuid();
                    while (result.Where(i => i.ImageId == newId).Count() != 0)
                    {
                        newId = Guid.NewGuid();
                    }

                    result.Add(new Image
                    {
                        ImageId = newId,
                        Filename = img,
                        CartridgeId = cart.Nid
                    });
                }
            }

            return result;
        }
    }
}
