using System;

namespace CartDB.API.Models
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public bool IsPrimary { get; set; }
    }
}
