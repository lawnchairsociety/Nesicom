using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Handlers
{
    public interface ICartridgeHandler
    {
        /// <summary>
        /// Gets a list of all cartridge
        /// </summary>
        /// <returns>list of cartridge</returns>
        Task<List<CartridgeDto>> GetAllCartridgesAsync();

        /// <summary>
        /// Gets a cartridge by its ID
        /// </summary>
        /// <param name="id">the id of the Cartridge wanted</param>
        /// <returns>a cartridge</returns>
        Task<CartridgeDto> GetCartridgeByIdAsync(Guid id);

        /// <summary>
        /// Gets a list of cartridges by their manufacturer's name
        /// </summary>
        /// <param name="name">the name of the manufacturer of the cartridges</param>
        /// <returns>a list of cartridges</returns>
        Task<List<CartridgeDto>> GetCartridgesByManufacturerNameAsync(string name);

        /// <summary>
        /// Gets a list of cartridges by their manufacturer's id
        /// </summary>
        /// <param name="id">the id of the manufacturer of the cartridges</param>
        /// <returns>a list of cartridges</returns>
        Task<List<CartridgeDto>> GetCartridgesByManufacturerIdAsync(Guid id);

        /// <summary>
        /// Gets a list cartridges by the chip's part number
        /// </summary>
        /// <param name="partnumber">the partnumber of the chip in the cartridges</param>
        /// <returns>a list of cartridges</returns>
        Task<List<CartridgeDto>> GetCartridgesByChipPartNumberAsync(string partnumber);

        /// <summary>
        /// Gets a list cartridges by the chip's id
        /// </summary>
        /// <param name="id">the id of the chip in the cartridges</param>
        /// <returns>a list of cartridges</returns>
        Task<List<CartridgeDto>> GetCartridgesByChipIdAsync(Guid id);
    }
}
