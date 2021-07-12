using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartDB.API.Mappers;
using CartDB.API.Models;
using CartDB.Database.Data;
using CartDB.Database.Models;
using Serilog;

namespace CartDB.API.Handlers
{
    public class CartridgeHandler : ICartridgeHandler
    {
        private static readonly ILogger Logger = Log.ForContext<CartridgeHandler>();
        private readonly NesicomPostgreContext _context;
        private readonly CartridgeModelToDtoMapper _cartridgeMapper;

        public CartridgeHandler(NesicomPostgreContext context, CartridgeModelToDtoMapper cartridgeMapper)
        {
            this._context = context;
            this._cartridgeMapper = cartridgeMapper;
        }

        public async Task<List<CartridgeDto>> GetAllCartridgesAsync(int offset, int count)
        {
            var cartridges = this._context.Cartridges.Skip(offset).Take(count).ToList();

            for (var i = 0; i < cartridges.Count; i++)
            {
                cartridges[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cartridges[i].ManufacturerId);
                cartridges[i].Pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == cartridges[i].PcbId);
                cartridges[i].Game = this._context.Games.FirstOrDefault(g => g.GameId == cartridges[i].GameId);
                cartridges[i].Images = this._context.Images.Where(m => m.CartridgeId == cartridges[i].CartridgeId).ToList();
                cartridges[i].CartridgeChips = this._context.CartridgeChips.Where(c => c.CartridgeId == cartridges[i].CartridgeId).ToList();

                foreach (var chip in cartridges[i].CartridgeChips)
                {
                    chip.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == chip.ManufacturerId);
                }

                cartridges[i].Pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == cartridges[i].Pcb.ManufacturerId);
                cartridges[i].Pcb.Images = this._context.Images.Where(m => m.PcbId == cartridges[i].PcbId).ToList();
                cartridges[i].Game.Developer = this._context.Developers.FirstOrDefault(c => c.DeveloperId == cartridges[i].Game.DeveloperId);
                cartridges[i].Game.Publisher = this._context.Publishers.FirstOrDefault(c => c.PublisherId == cartridges[i].Game.PublisherId);
                cartridges[i].Game.Region = this._context.Regions.FirstOrDefault(c => c.RegionId == cartridges[i].Game.RegionId);
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }

        public async Task<CartridgeDto> GetCartridgeByIdAsync(Guid id)
        {
            var cartridge = this._context.Cartridges
                            .FirstOrDefault(c => c.CartridgeId == id);

            cartridge.Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cartridge.ManufacturerId);
            cartridge.Pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == cartridge.PcbId);
            cartridge.Game = this._context.Games.FirstOrDefault(g => g.GameId == cartridge.GameId);
            cartridge.Images = this._context.Images.Where(m => m.CartridgeId == cartridge.CartridgeId).ToList();
            cartridge.CartridgeChips = this._context.CartridgeChips.Where(c => c.CartridgeId == cartridge.CartridgeId).ToList();

            foreach(var chip in cartridge.CartridgeChips)
            {
                chip.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == chip.ManufacturerId);
            }

            cartridge.Pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == cartridge.Pcb.ManufacturerId);
            cartridge.Pcb.Images = this._context.Images.Where(m => m.PcbId == cartridge.PcbId).ToList();
            cartridge.Game.Developer = this._context.Developers.FirstOrDefault(c => c.DeveloperId == cartridge.Game.DeveloperId);
            cartridge.Game.Publisher = this._context.Publishers.FirstOrDefault(c => c.PublisherId == cartridge.Game.PublisherId);
            cartridge.Game.Region = this._context.Regions.FirstOrDefault(c => c.RegionId == cartridge.Game.RegionId);

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
                cartridges[i].Game = this._context.Games.FirstOrDefault(g => g.GameId == cartridges[i].GameId);
                cartridges[i].Images = this._context.Images.Where(m => m.CartridgeId == cartridges[i].CartridgeId).ToList();
                cartridges[i].CartridgeChips = this._context.CartridgeChips.Where(c => c.CartridgeId == cartridges[i].CartridgeId).ToList();

                foreach (var chip in cartridges[i].CartridgeChips)
                {
                    chip.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == chip.ManufacturerId);
                }

                cartridges[i].Pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == cartridges[i].Pcb.ManufacturerId);
                cartridges[i].Pcb.Images = this._context.Images.Where(m => m.PcbId == cartridges[i].PcbId).ToList();
                cartridges[i].Game.Developer = this._context.Developers.FirstOrDefault(c => c.DeveloperId == cartridges[i].Game.DeveloperId);
                cartridges[i].Game.Publisher = this._context.Publishers.FirstOrDefault(c => c.PublisherId == cartridges[i].Game.PublisherId);
                cartridges[i].Game.Region = this._context.Regions.FirstOrDefault(c => c.RegionId == cartridges[i].Game.RegionId);
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
                cartridges[i].Game = this._context.Games.FirstOrDefault(g => g.GameId == cartridges[i].GameId);
                cartridges[i].Images = this._context.Images.Where(m => m.CartridgeId == cartridges[i].CartridgeId).ToList();
                cartridges[i].CartridgeChips = this._context.CartridgeChips.Where(c => c.CartridgeId == cartridges[i].CartridgeId).ToList();

                foreach (var chip in cartridges[i].CartridgeChips)
                {
                    chip.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == chip.ManufacturerId);
                }

                cartridges[i].Pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == cartridges[i].Pcb.ManufacturerId);
                cartridges[i].Pcb.Images = this._context.Images.Where(m => m.PcbId == cartridges[i].PcbId).ToList();
                cartridges[i].Game.Developer = this._context.Developers.FirstOrDefault(c => c.DeveloperId == cartridges[i].Game.DeveloperId);
                cartridges[i].Game.Publisher = this._context.Publishers.FirstOrDefault(c => c.PublisherId == cartridges[i].Game.PublisherId);
                cartridges[i].Game.Region = this._context.Regions.FirstOrDefault(c => c.RegionId == cartridges[i].Game.RegionId);
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
                cartridges[i].Game = this._context.Games.FirstOrDefault(g => g.GameId == cartridges[i].GameId);
                cartridges[i].Images = this._context.Images.Where(m => m.CartridgeId == cartridges[i].CartridgeId).ToList();
                cartridges[i].CartridgeChips = this._context.CartridgeChips.Where(c => c.CartridgeId == cartridges[i].CartridgeId).ToList();

                foreach (var chip in cartridges[i].CartridgeChips)
                {
                    chip.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == chip.ManufacturerId);
                }

                cartridges[i].Pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == cartridges[i].Pcb.ManufacturerId);
                cartridges[i].Pcb.Images = this._context.Images.Where(m => m.PcbId == cartridges[i].PcbId).ToList();
                cartridges[i].Game.Developer = this._context.Developers.FirstOrDefault(c => c.DeveloperId == cartridges[i].Game.DeveloperId);
                cartridges[i].Game.Publisher = this._context.Publishers.FirstOrDefault(c => c.PublisherId == cartridges[i].Game.PublisherId);
                cartridges[i].Game.Region = this._context.Regions.FirstOrDefault(c => c.RegionId == cartridges[i].Game.RegionId);
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
                cartridges[i].Game = this._context.Games.FirstOrDefault(g => g.GameId == cartridges[i].GameId);
                cartridges[i].Images = this._context.Images.Where(m => m.CartridgeId == cartridges[i].CartridgeId).ToList();
                cartridges[i].CartridgeChips = this._context.CartridgeChips.Where(c => c.CartridgeId == cartridges[i].CartridgeId).ToList();

                foreach (var chip in cartridges[i].CartridgeChips)
                {
                    chip.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == chip.ManufacturerId);
                }

                cartridges[i].Pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == cartridges[i].Pcb.ManufacturerId);
                cartridges[i].Pcb.Images = this._context.Images.Where(m => m.PcbId == cartridges[i].PcbId).ToList();
                cartridges[i].Game.Developer = this._context.Developers.FirstOrDefault(c => c.DeveloperId == cartridges[i].Game.DeveloperId);
                cartridges[i].Game.Publisher = this._context.Publishers.FirstOrDefault(c => c.PublisherId == cartridges[i].Game.PublisherId);
                cartridges[i].Game.Region = this._context.Regions.FirstOrDefault(c => c.RegionId == cartridges[i].Game.RegionId);
            }

            var result = this._cartridgeMapper.MapDto(cartridges).ToList();

            return result;
        }
    }
}
