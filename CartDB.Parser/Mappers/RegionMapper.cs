using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class RegionMapper
    {
        public static Region Map(RegionModel model, NesicomContext context)
        {
            var region = context.Regions.FirstOrDefault(o => o.RegionName == model.Name);
            if (region == null)
            {
                region = new Region
                {
                    RegionName = model.Name,
                    Image = model.Image
                };
            }

            return region;
        }
    }
}
