using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class OtherChip
    {
        public OtherChip()
        {
            PcbOtherChips = new HashSet<PcbOtherChip>();
        }

        [Key]
        public Guid OtherChipId { get; set; }
        [Required]
        public string OtherChipName { get; set; }

        [InverseProperty(nameof(PcbOtherChip.OtherChip))]
        public virtual ICollection<PcbOtherChip> PcbOtherChips { get; set; }
    }
}
