using System;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class OtherChip
    {
#nullable enable
        [Key]
        public Guid OtherChipId { get; set; }
        [Required]
        public string OtherChipName { get; set; }
#nullable disable
    }
}
