using System.Collections.Generic;
using System.Linq;

namespace CartDB.API.Mappers
{
    public abstract class AbstractModelToDtoMapper<TModel, TDto>
        : IModelToDtoMapper<TModel, TDto>
    {
        public abstract TDto MapDto(TModel model);

        public virtual IList<TDto> MapDto(IEnumerable<TModel> models)
        {
            return models.Select(MapDto).ToList();
        }
    }
}
