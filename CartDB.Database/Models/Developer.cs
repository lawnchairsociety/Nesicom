using System;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Developer
    {
        [Key]
        public Guid DeveloperId { get; set; }
        [Required]
        public string DeveloperName { get; set; }
    }
}
