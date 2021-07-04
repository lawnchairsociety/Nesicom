using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class ManufacturerImage
    {
        [Key]
        public Guid ManufacturerImageId { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        [InverseProperty("ManufacturerImages")]
        public virtual Image Image { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty("ManufacturerImages")]
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
