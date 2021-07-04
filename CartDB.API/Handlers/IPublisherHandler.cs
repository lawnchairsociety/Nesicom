using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface IPublisherHandler
    {
        /// <summary>
        /// Gets a list of all publishers
        /// </summary>
        /// <returns>list of publishers</returns>
        Task<List<PublisherDto>> GetAllPublishersAsync();

        /// <summary>
        /// Gets a publisher by its ID
        /// </summary>
        /// <param name="id">the id of the publisher wanted</param>
        /// <returns>a publisher</returns>
        Task<PublisherDto> GetPublisherByIdAsync(Guid id);

        /// <summary>
        /// Gets a publisher by its name
        /// </summary>
        /// <param name="name">the name of the publisher wanted</param>
        /// <returns>a publisher</returns>
        Task<PublisherDto> GetPublisherByNameAsync(string name);
    }
}
