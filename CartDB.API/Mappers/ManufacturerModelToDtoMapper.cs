using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class ManufacturerModelToDtoMapper : AbstractModelToDtoMapper<Manufacturer, ManufacturerDto>
    {
        public override ManufacturerDto MapDto(Manufacturer model)
        {
            if (model == null)
            {
                return null;
            }

            return new ManufacturerDto
            {
                Id = model.ManufacturerId,
                Name = model.ManufacturerName,
                Image = model.Image
            };
        }
    }
}
