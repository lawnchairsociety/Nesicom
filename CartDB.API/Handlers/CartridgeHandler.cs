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
                var manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == this._context.Cartridges.Select(p => p.ManufacturerId).FirstOrDefault());
                var pcb = this._context.Pcbs.FirstOrDefault(m => m.PcbId == this._context.Cartridges.Select(p => p.PcbId).FirstOrDefault());

                if (manufacturer != null)
                {
                    cartridges[i].Manufacturer = manufacturer;
                }

                if (pcb != null)
                {
                    cartridges[i].Pcb = pcb;
                }
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }

        public async Task<CartridgeDto> GetCartridgeByIdAsync(Guid id)
        {
            var cartridge = this._context.Cartridges
                            .Where(c => c.CartridgeId == id)
                            .FirstOrDefault();

            var manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == this._context.Cartridges.Select(p => p.ManufacturerId).FirstOrDefault());
            var pcb = this._context.Pcbs.FirstOrDefault(m => m.PcbId == this._context.Cartridges.Select(p => p.PcbId).FirstOrDefault());

            if (manufacturer != null)
            {
                cartridge.Manufacturer = manufacturer;
            }

            if (pcb != null)
            {
                cartridge.Pcb = pcb;
            }

            var result = this._cartridgeMapper.MapDto(cartridge);

            return result;
        }

        public async Task<List<CartridgeDto>> GetCartridgesByChipIdAsync(Guid id)
        {
            var cartridges = this._context.CartridgeCartridgeChips
                                .Where(c => c.CartridgeChipId == id)
                                .Select(ch => ch.Cartridge)
                                .ToList();

            for (var i = 0; i < cartridges.Count; i++)
            {
                var manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == this._context.Cartridges.Select(p => p.ManufacturerId).FirstOrDefault());
                var pcb = this._context.Pcbs.FirstOrDefault(m => m.PcbId == this._context.Cartridges.Select(p => p.PcbId).FirstOrDefault());

                if (manufacturer != null)
                {
                    cartridges[i].Manufacturer = manufacturer;
                }

                if (pcb != null)
                {
                    cartridges[i].Pcb = pcb;
                }
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }

        public async Task<List<CartridgeDto>> GetCartridgesByChipPartNumberAsync(string partnumber)
        {
            var chipIds = this._context.CartridgeChips.Where(c => c.PartNumber == partnumber).Select(p => p.CartridgeChipId).ToList();
            var cartridges = new List<Cartridge>();

            foreach (var id in chipIds)
            {
                var cart = this._context.Cartridges.FirstOrDefault(c => c.CartridgeCartridgeChips.Contains(new CartridgeCartridgeChip { CartridgeChipId = id }));
                if (cart != null)
                {
                    cartridges.Add(cart);
                }
            }

            for (var i = 0; i < cartridges.Count; i++)
            {
                var manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == this._context.Cartridges.Select(p => p.ManufacturerId).FirstOrDefault());
                var pcb = this._context.Pcbs.FirstOrDefault(m => m.PcbId == this._context.Cartridges.Select(p => p.PcbId).FirstOrDefault());

                if (manufacturer != null)
                {
                    cartridges[i].Manufacturer = manufacturer;
                }

                if (pcb != null)
                {
                    cartridges[i].Pcb = pcb;
                }
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
                var manufacturerId = this._context.Cartridges.Select(p => p.ManufacturerId).FirstOrDefault();
                var pcbId = this._context.Cartridges.Select(p => p.PcbId).FirstOrDefault();

                cartridges[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);
                cartridges[i].Pcb = this._context.Pcbs.FirstOrDefault(m => m.PcbId == pcbId);
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
                var manufacturerId = this._context.Cartridges.Select(p => p.ManufacturerId).FirstOrDefault();
                var pcbId = this._context.Cartridges.Select(p => p.PcbId).FirstOrDefault();

                cartridges[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);
                cartridges[i].Pcb = this._context.Pcbs.FirstOrDefault(m => m.PcbId == pcbId);
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }
    }
}
