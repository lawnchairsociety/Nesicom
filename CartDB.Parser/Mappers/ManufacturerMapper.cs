using System;
using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class ManufacturerMapper
    {
        public static Manufacturer Map(ProducerModel model, NesicomSqlServerContext context)
        {
            var manufacturer = context.Manufacturers.FirstOrDefault(o => o.ManufacturerName == model.Name);
            if (manufacturer == null)
            {
                manufacturer = new Manufacturer
                {
                    ManufacturerName = model.Name,
                    Image = model.Image
                };
            }

            return manufacturer;
        }
    }
}
