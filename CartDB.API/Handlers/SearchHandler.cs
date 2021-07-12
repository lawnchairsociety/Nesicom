using System.Linq;
using System.Threading.Tasks;
using CartDB.API.Mappers;
using CartDB.API.Models;
using CartDB.Database.Data;
using Serilog;

namespace CartDB.API.Handlers
{
    public class SearchHandler : ISearchHandler
    {
        private static readonly ILogger Logger = Log.ForContext<RegionHandler>();
        private readonly NesicomContext _context;
        private readonly CartridgeChipModelToDtoMapper _cartridgeChipMapper;
        private readonly CartridgeModelToDtoMapper _cartridgeMapper;
        private readonly DeveloperModelToDtoMapper _developerMapper;
        private readonly GameModelToDtoMapper _gameMapper;
        private readonly ManufacturerModelToDtoMapper _manufacturerMapper;
        private readonly PcbModelToDtoMapper _pcbMapper;
        private readonly PublisherModelToDtoMapper _publisherMapper;
        private readonly RegionModelToDtoMapper _regionMapper;

        public SearchHandler(NesicomContext context, CartridgeChipModelToDtoMapper cartridgeChipMapper, CartridgeModelToDtoMapper cartridgeMapper,
            DeveloperModelToDtoMapper developerMapper, GameModelToDtoMapper gameMapper, ManufacturerModelToDtoMapper manufacturerMapper,
            PcbModelToDtoMapper pcbMapper, PublisherModelToDtoMapper publisherMapper, RegionModelToDtoMapper regionMapper)
        {
            this._context = context;
            this._cartridgeChipMapper = cartridgeChipMapper;
            this._cartridgeMapper = cartridgeMapper;
            this._developerMapper = developerMapper;
            this._gameMapper = gameMapper;
            this._manufacturerMapper = manufacturerMapper;
            this._pcbMapper = pcbMapper;
            this._publisherMapper = publisherMapper;
            this._regionMapper = regionMapper;
        }

        public async Task<SearchDto> SearchContextsAsync(string query)
        {
            var cartridgeChips = this._context.CartridgeChips.Where(o => o.PartNumber.Contains(query)).ToList();
            var developers = this._context.Developers.Where(o => o.DeveloperName.Contains(query)).ToList();
            var manufacturers = this._context.Manufacturers.Where(o => o.ManufacturerName.Contains(query)).ToList();
            var publishers = this._context.Publishers.Where(o => o.PublisherName.Contains(query)).ToList();
            var regions = this._context.Regions.Where(o => o.RegionName.Contains(query)).ToList();
            var cartridges = this._context.Cartridges.Where(o =>
                    o.Color.Contains(query) ||
                    o.CICType.Contains(query) ||
                    o.FormFactor.Contains(query) ||
                    o.BackLabelEntry.Contains(query) ||
                    o.FrontLabelEntry.Contains(query) ||
                    o.EmbossedText.Contains(query) ||
                    o.Hardware.Contains(query) ||
                    o.Revision.Contains(query) ||
                    o.TwoDigitCode.Contains(query) ||
                    o.VRAM.Contains(query) ||
                    o.WRAM.Contains(query) ||
                    o.SealOfQuality.Contains(query)).ToList();

            var games = this._context.Games.Where(o => 
                    o.CatalogEntry.Contains(query) ||
                    o.Class.Contains(query) ||
                    o.GameName.Contains(query) ||
                    o.Peripherals.Contains(query)).ToList();

            var pcbs = this._context.Pcbs.Where(o =>
                    o.CIC.Contains(query) ||
                    o.PcbName.Contains(query) ||
                    o.PcbNotes.Contains(query) ||
                    o.PcbClass.Contains(query) ||
                    o.Mapper.Contains(query) ||
                    o.PrgRom.Contains(query) ||
                    o.PrgRam.Contains(query) ||
                    o.ChrRom.Contains(query) ||
                    o.ChrRam.Contains(query) ||
                    o.OtherChips.Contains(query)).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
            }

            var mappedChips = this._cartridgeChipMapper.MapDto(cartridgeChips).ToList();
            var mappedCarts = this._cartridgeMapper.MapDto(cartridges).ToList();
            var mappedDevs = this._developerMapper.MapDto(developers).ToList();
            var mappedGames = this._gameMapper.MapDto(games).ToList();
            var mappedManus = this._manufacturerMapper.MapDto(manufacturers).ToList();
            var mappedPcbs = this._pcbMapper.MapDto(pcbs).ToList();
            var mappedPubs = this._publisherMapper.MapDto(publishers).ToList();
            var mappedRegs = this._regionMapper.MapDto(regions).ToList();

            return new SearchDto
            {
                CartridgeChips = mappedChips,
                Cartridges = mappedCarts,
                Developers = mappedDevs,
                Games = mappedGames,
                Manufacturers = mappedManus,
                Pcbs = mappedPcbs,
                Publishers = mappedPubs,
                Regions = mappedRegs
            };
        }
    }
}
