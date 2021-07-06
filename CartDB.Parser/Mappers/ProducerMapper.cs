using System;
using System.Collections.Generic;
using System.Linq;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public static class ProducerMapper
    {
        public static List<Manufacturer> MapData(List<TransientProducerModel> producers, List<TransientPcbModel> pcbs)
        {
            var result = new List<Manufacturer>();

            foreach (var prod in producers)
            {
                if (!string.IsNullOrEmpty(prod.Name) && result.Where(m => m.ManufacturerName == prod.Name).Count() == 0)
                {
                    result.Add(new Manufacturer
                    {
                        ManufacturerId = prod.Nid,
                        ManufacturerName = prod.Name,
                        Image = prod.Image
                    });
                }
            }

            foreach (var pcb in pcbs)
            {
                if (!string.IsNullOrEmpty(pcb.Manufacturer) && result.Where(m => m.ManufacturerName == pcb.Manufacturer).Count() == 0)
                {
                    var newId = Guid.NewGuid();
                    while (result.Where(i => i.ManufacturerId == newId).Count() != 0)
                    {
                        newId = Guid.NewGuid();
                    }
                    result.Add(new Manufacturer
                    {
                        ManufacturerId = newId,
                        ManufacturerName = pcb.Manufacturer,
                        Image = pcb.ManufacturerLogo
                    });
                }
            }

            return result;
        }
    }
}
