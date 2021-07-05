using System;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Publisher
    {
        [Key]
        public Guid PublisherId { get; set; }
        [Required]
        public string PublisherName { get; set; }
    }
}
