using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class DeveloperModelToDtoMapper : AbstractModelToDtoMapper<Developer, DeveloperDto>
    {
        public override DeveloperDto MapDto(Developer model)
        {
            if (model == null)
            {
                return null;
            }

            return new DeveloperDto
            {
                Id = model.DeveloperId,
                Name = model.DeveloperName
            };
        }
    }
}
