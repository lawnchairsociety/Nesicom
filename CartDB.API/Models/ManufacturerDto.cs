using System;
using System.Collections.Generic;

namespace CartDB.API.Models
{
    public class ManufacturerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ImageDto> Images { get; set; }
    }
}
