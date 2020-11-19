using System;
using System.Collections.Generic;
using System.Text;

namespace ePizza_JD.Models
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }

    }
}
