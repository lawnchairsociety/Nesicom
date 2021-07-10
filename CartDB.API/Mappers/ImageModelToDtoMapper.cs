using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class ImageModelToDtoMapper : AbstractModelToDtoMapper<Image, ImageDto>
    {
        public override ImageDto MapDto(Image model)
        {
            if (model == null)
            {
                return null;
            }

            return new ImageDto
            {
                Id = model.ImageId,
                Filename = model.Filename
            };
        }
    }
}
