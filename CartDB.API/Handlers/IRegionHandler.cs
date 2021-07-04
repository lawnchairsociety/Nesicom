using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface IRegionHandler
    {
        /// <summary>
        /// Gets a list of all regions
        /// </summary>
        /// <returns>list of regions</returns>
        Task<List<RegionDto>> GetAllRegionsAsync();

        /// <summary>
        /// Gets a region by its ID
        /// </summary>
        /// <param name="id">the id of the region wanted</param>
        /// <returns>a region</returns>
        Task<RegionDto> GetRegionByIdAsync(Guid id);

        /// <summary>
        /// Gets a region by its name
        /// </summary>
        /// <param name="name">the name of the region wanted</param>
        /// <returns>a region</returns>
        Task<RegionDto> GetRegionByNameAsync(string name);
    }
}
