using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public virtual User User { get; set; }
    }
}
