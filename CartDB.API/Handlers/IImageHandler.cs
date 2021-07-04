using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface IImageHandler
    {
        /// <summary>
        /// Gets the image URL
        /// </summary>
        /// <param name="id">id of the image</param>
        /// <returns>list of urls for the image</returns>
        Task<List<ImageDto>> GetImageUrlByIdAsync(Guid id);
    }
}
