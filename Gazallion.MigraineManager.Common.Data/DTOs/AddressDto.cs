using System;
using System.Collections.Generic;
using System.Linq;

namespace Gazallion.MigraineManager.Common.Data.DTOs
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
    }
}