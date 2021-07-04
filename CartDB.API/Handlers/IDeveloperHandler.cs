using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface IDeveloperHandler
    {
        /// <summary>
        /// Gets a list of all developers
        /// </summary>
        /// <returns>list of developers</returns>
        Task<List<DeveloperDto>> GetAllDevelopersAsync();

        /// <summary>
        /// Gets a developer by its ID
        /// </summary>
        /// <param name="id">the id of the developer wanted</param>
        /// <returns>a developer</returns>
        Task<DeveloperDto> GetDeveloperByIdAsync(Guid id);

        /// <summary>
        /// Gets a developer by its name
        /// </summary>
        /// <param name="name">the name of the developer wanted</param>
        /// <returns>a developer</returns>
        Task<DeveloperDto> GetDeveloperByNameAsync(string name);
    }
}
