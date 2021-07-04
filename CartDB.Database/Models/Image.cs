using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class Image
    {
        public Image()
        {
            CartridgeImages = new HashSet<CartridgeImage>();
            ManufacturerImages = new HashSet<ManufacturerImage>();
            PcbImages = new HashSet<PcbImage>();
        }

        [Key]
        public Guid ImageId { get; set; }
        [Required]
        public string Filename { get; set; }

        [InverseProperty(nameof(CartridgeImage.Image))]
        public virtual ICollection<CartridgeImage> CartridgeImages { get; set; }
        [InverseProperty(nameof(ManufacturerImage.Image))]
        public virtual ICollection<ManufacturerImage> ManufacturerImages { get; set; }
        [InverseProperty(nameof(PcbImage.Image))]
        public virtual ICollection<PcbImage> PcbImages { get; set; }
    }
}
