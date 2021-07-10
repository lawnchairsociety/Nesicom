using System.Linq;
using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class CartridgeModelToDtoMapper : AbstractModelToDtoMapper<Cartridge, CartridgeDto>
    {
        public override CartridgeDto MapDto(Cartridge model)
        {
            ManufacturerModelToDtoMapper manufacturerMapper = new ManufacturerModelToDtoMapper();
            PcbModelToDtoMapper pcbMapper = new PcbModelToDtoMapper();
            GameModelToDtoMapper gameMapper = new GameModelToDtoMapper();
            ImageModelToDtoMapper imageMapper = new ImageModelToDtoMapper();
            CartridgeChipModelToDtoMapper cartridgeChipMapper = new CartridgeChipModelToDtoMapper();

            if (model == null)
            {
                return null;
            }

            return new CartridgeDto
            {
                Id = model.CartridgeId,
                Game = gameMapper.MapDto(model.Game),
                Manufacturer = manufacturerMapper.MapDto(model.Manufacturer),
                Pcb = pcbMapper.MapDto(model.Pcb),
                Color = model.Color,
                FormFactor = model.FormFactor,
                EmbossedText = model.EmbossedText,
                FrontLabelEntry = model.FrontLabelEntry,
                SealOfQuality = model.SealOfQuality,
                MfgStringPresent = model.MfgStrPresent,
                BackLabelEntry = model.BackLabelEntry,
                TwoDigitCode = model.TwoDigitCode,
                Revision = model.Revision,
                CICType = model.CICType,
                Hardware = model.Hardware,
                WRAM = model.WRAM,
                VRAM = model.VRAM,
                Images = imageMapper.MapDto(model.Images).ToList(),
                CartridgeChips = cartridgeChipMapper.MapDto(model.CartridgeChips).ToList()
            };
        }
    }
}
