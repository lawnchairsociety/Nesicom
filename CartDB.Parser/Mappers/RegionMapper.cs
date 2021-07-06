using System;
using System.Collections.Generic;
using System.Linq;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public static class RegionMapper
    {
        public static List<Region> MapData(List<TransientRegionModel> regions)
        {
            var result = new List<Region>();

            foreach (var reg in regions)
            {
                if (!string.IsNullOrEmpty(reg.Name) && result.Where(r => r.RegionName == reg.Name).Count() == 0)
                {
                    result.Add(new Region
                    {
                        RegionId = reg.Nid,
                        RegionName = reg.Name,
                        Image = reg.Image
                    });
                }
            }

            return result;
        }
    }
}
