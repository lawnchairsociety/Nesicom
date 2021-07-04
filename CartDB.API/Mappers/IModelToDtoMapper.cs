using System.Collections.Generic;

namespace CartDB.API.Mappers
{
    /// <summary>
    /// Allows for mapping of database models to their DTOs
    /// </summary>
    /// <typeparam name="TModel">The database model tyoe</typeparam>
    /// <typeparam name="TDto">The DTO type</typeparam>
    public interface IModelToDtoMapper<in TModel, TDto>
    {
        /// <summary>
        /// Maps the TModel object to a TDto object
        /// </summary>
        /// <param name="model">TModel object to be mapped</param>
        /// <returns>TDto object that was mapped</returns>
        TDto MapDto(TModel model);

        /// <summary>
        /// Maps a collection to TModel objects to a collection of TDtos
        /// </summary>
        /// <param name="models">Collection of TModels</param>
        /// <returns>Collection of TDtos</returns>
        IList<TDto> MapDto(IEnumerable<TModel> models);
    }
}
