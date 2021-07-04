using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface IManufacturerHandler
    {
        /// <summary>
        /// Gets a list of all manufacturers
        /// </summary>
        /// <returns>list of manufacturers</returns>
        Task<List<ManufacturerDto>> GetAllManufacturersAsync();

        /// <summary>
        /// Gets a manufacturer by its ID
        /// </summary>
        /// <param name="id">the id of the manufacturer wanted</param>
        /// <returns>a manufacturer</returns>
        Task<ManufacturerDto> GetManufacturerByIdAsync(Guid id);

        /// <summary>
        /// Gets a manufacturer by its name
        /// </summary>
        /// <param name="name">the name of the manufacturer wanted</param>
        /// <returns>a manufacturer</returns>
        Task<ManufacturerDto> GetManufacturerByNameAsync(string name);
    }
}
