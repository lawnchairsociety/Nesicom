using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CartDB.Database.Models
{
    public partial class PcbImage
    {
        [Key]
        public Guid PcbImageId { get; set; }
        public Guid PcbId { get; set; }
        public Guid ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        [InverseProperty("PcbImages")]
        public virtual Image Image { get; set; }
        [ForeignKey(nameof(PcbId))]
        [InverseProperty("PcbImages")]
        public virtual Pcb Pcb { get; set; }
    }
}
