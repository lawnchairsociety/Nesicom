using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            CartridgeChips = new HashSet<CartridgeChip>();
            Cartridges = new HashSet<Cartridge>();
            ManufacturerImages = new HashSet<ManufacturerImage>();
            Pcbs = new HashSet<Pcb>();
        }

        [Key]
        public Guid ManufacturerId { get; set; }
        [Required]
        public string ManufacturerName { get; set; }

        [InverseProperty(nameof(CartridgeChip.Manufacturer))]
        public virtual ICollection<CartridgeChip> CartridgeChips { get; set; }
        [InverseProperty(nameof(Cartridge.Manufacturer))]
        public virtual ICollection<Cartridge> Cartridges { get; set; }
        [InverseProperty(nameof(ManufacturerImage.Manufacturer))]
        public virtual ICollection<ManufacturerImage> ManufacturerImages { get; set; }
        [InverseProperty(nameof(Pcb.Manufacturer))]
        public virtual ICollection<Pcb> Pcbs { get; set; }
    }
}
