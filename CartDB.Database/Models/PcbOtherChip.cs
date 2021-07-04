using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class PcbOtherChip
    {
        [Key]
        public Guid PcbOtherChipId { get; set; }
        public Guid PcbId { get; set; }
        public Guid OtherChipId { get; set; }

        [ForeignKey(nameof(OtherChipId))]
        [InverseProperty("PcbOtherChips")]
        public virtual OtherChip OtherChip { get; set; }
        [ForeignKey(nameof(PcbId))]
        [InverseProperty("PcbOtherChips")]
        public virtual Pcb Pcb { get; set; }
    }
}
