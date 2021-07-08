using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Pcb
    {
        public Pcb()
        {
            Images = new HashSet<Image>();
        }

#nullable enable
        [Key]
        public Guid PcbId { get; set; }
        public Guid? ManufacturerId { get; set; }
        [Required]
        public string PcbName { get; set; }
        public string? PcbNotes { get; set; }
        public DateTime? LifeSpanStart { get; set; }
        public DateTime? LifeSpanEnd { get; set; }
        public string? PcbClass { get; set; }
        public string? Mapper { get; set; }
        public string? PrgRom { get; set; }
        public string? PrgRam { get; set; }
        public string? ChrRom { get; set; }
        public string? ChrRam { get; set; }
        public int BatteryPresent { get; set; }
        public int Mirroring { get; set; }
        public string? CIC { get; set; }
        public string? OtherChips { get; set; }
#nullable disable

        public virtual ICollection<Image> Images { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
