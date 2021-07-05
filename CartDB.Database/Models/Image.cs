﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CartDB.Database.Models
{
    public class Image
    {
        [Key]
        public Guid ImageId { get; set; }
        [Required]
        public string Filename { get; set; }
    }
}
