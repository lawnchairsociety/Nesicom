using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class CartridgeImage
    {
        [Key]
        public Guid CartridgeImageId { get; set; }
        public Guid CartridgeId { get; set; }
        public Guid ImageId { get; set; }

        [ForeignKey(nameof(CartridgeId))]
        [InverseProperty("CartridgeImages")]
        public virtual Cartridge Cartridge { get; set; }
        [ForeignKey(nameof(ImageId))]
        [InverseProperty("CartridgeImages")]
        public virtual Image Image { get; set; }
    }
}
