using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class CartridgeChipModelToDtoMapper : AbstractModelToDtoMapper<CartridgeChip, CartridgeChipDto>
    {
        public override CartridgeChipDto MapDto(CartridgeChip model)
        {
            ManufacturerModelToDtoMapper manufacturerMapper = new ManufacturerModelToDtoMapper();

            if (model == null)
            {
                return null;
            }

            return new CartridgeChipDto
            {
                Id = model.CartridgeChipId,
                PartNumber = model.PartNumber,
                Manufacturer = manufacturerMapper.MapDto(model.Manufacturer),
                Designation = model.Designation,
                Type = model.Type,
                Package = model.Package
            };
        }
    }
}
