using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class Pcb
    {
        public Pcb()
        {
            Cartridges = new HashSet<Cartridge>();
            PcbImages = new HashSet<PcbImage>();
            PcbOtherChips = new HashSet<PcbOtherChip>();
        }

        [Key]
        public Guid PcbId { get; set; }
        public Guid? ManufacturerId { get; set; }
        [Required]
        public string PcbName { get; set; }
        [Required]
        public string PcbNotes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LifeSpanStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LifeSpanEnd { get; set; }
        [Required]
        public string PcbClass { get; set; }
        [Required]
        public string Mapper { get; set; }
        public string PrgRom { get; set; }
        public string PrgRam { get; set; }
        public string ChrRom { get; set; }
        public string ChrRam { get; set; }
        public int BatteryPresent { get; set; }
        public int Mirroring { get; set; }
        [Column("CIC")]
        public string Cic { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty("Pcbs")]
        public virtual Manufacturer Manufacturer { get; set; }
        [InverseProperty(nameof(Cartridge.Pcb))]
        public virtual ICollection<Cartridge> Cartridges { get; set; }
        [InverseProperty(nameof(PcbImage.Pcb))]
        public virtual ICollection<PcbImage> PcbImages { get; set; }
        [InverseProperty(nameof(PcbOtherChip.Pcb))]
        public virtual ICollection<PcbOtherChip> PcbOtherChips { get; set; }
    }
}
