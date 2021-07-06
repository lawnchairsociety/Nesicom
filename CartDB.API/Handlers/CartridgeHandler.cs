using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.API.Models;
using CartDB.API.Mappers;
using CartDB.Database.Data;
using CartDB.Database.Models;
using Serilog;

namespace CartDB.API.Handlers
{
    public class CartridgeHandler : ICartridgeHandler
    {
        private static readonly ILogger Logger = Log.ForContext<CartridgeHandler>();
        private readonly NesicomContext _context;
        private readonly CartridgeModelToDtoMapper _cartridgeMapper;

        public CartridgeHandler(NesicomContext context, CartridgeModelToDtoMapper cartridgeMapper)
        {
            this._context = context;
            this._cartridgeMapper = cartridgeMapper;
        }

        public async Task<List<CartridgeDto>> GetAllCartridgesAsync()
        {
            var cartridges = this._context.Cartridges.ToList();

            for (var i = 0; i < cartridges.Count; i++)
            {
                cartridges[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cartridges[i].ManufacturerId);
                cartridges[i].Pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == cartridges[i].PcbId);
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }

        public async Task<CartridgeDto> GetCartridgeByIdAsync(Guid id)
        {
            var cartridge = this._context.Cartridges
                            .Where(c => c.CartridgeId == id)
                            .FirstOrDefault();

            cartridge.Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cartridge.ManufacturerId);
            cartridge.Pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == cartridge.PcbId);

            var result = this._cartridgeMapper.MapDto(cartridge);

            return result;
        }

        public async Task<List<CartridgeDto>> GetCartridgesByChipIdAsync(Guid id)
        {
            var cartridges = this._context.CartridgeChips
                                .Where(c => c.CartridgeChipId == id)
                                .Select(ch => ch.Cartridge)
                                .ToList();

            for (var i = 0; i < cartridges.Count; i++)
            {
                cartridges[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cartridges[i].ManufacturerId);
                cartridges[i].Pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == cartridges[i].PcbId);
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }

        public async Task<List<CartridgeDto>> GetCartridgesByChipPartNumberAsync(string partnumber)
        {
            var cartIds = this._context.CartridgeChips.Where(c => c.PartNumber == partnumber).Select(p => p.CartridgeId).ToList();
            var cartridges = new List<Cartridge>();

            foreach(var id in cartIds)
            {
                var newCart = this._context.Cartridges.Where(c => c.CartridgeId == id).FirstOrDefault();
                if (newCart != null)
                {
                    cartridges.Add(newCart);
                }
            }

            for (var i = 0; i < cartridges.Count; i++)
            {
                cartridges[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cartridges[i].ManufacturerId);
                cartridges[i].Pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == cartridges[i].PcbId);
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }

        public async Task<List<CartridgeDto>> GetCartridgesByManufacturerIdAsync(Guid id)
        {
            var cartridges = this._context.Cartridges
                                .Where(c => c.ManufacturerId == id)
                                .ToList();

            for (var i = 0; i < cartridges.Count; i++)
            {
                cartridges[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cartridges[i].ManufacturerId);
                cartridges[i].Pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == cartridges[i].PcbId);
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }

        public async Task<List<CartridgeDto>> GetCartridgesByManufacturerNameAsync(string name)
        {
            var cartridges = this._context.Cartridges
                                .Where(c => c.Manufacturer.ManufacturerName == name)
                                .ToList();

            for (var i = 0; i < cartridges.Count; i++)
            {
                cartridges[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cartridges[i].ManufacturerId);
                cartridges[i].Pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == cartridges[i].PcbId);
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }
    }
}
