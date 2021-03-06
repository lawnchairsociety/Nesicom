using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class RegionModelToDtoMapper : AbstractModelToDtoMapper<Region, RegionDto>
    {
        public override RegionDto MapDto(Region model)
        {
            if (model == null)
            {
                return null;
            }

            return new RegionDto
            {
                Id = model.RegionId,
                Name = model.RegionName,
                Image = model.Image
            };
        }
    }
}
