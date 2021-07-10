using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class PublisherModelToDtoMapper : AbstractModelToDtoMapper<Publisher, PublisherDto>
    {
        public override PublisherDto MapDto(Publisher model)
        {
            if (model == null)
            {
                return null;
            }

            return new PublisherDto
            {
                Id = model.PublisherId,
                Name = model.PublisherName
            };
        }
    }
}
