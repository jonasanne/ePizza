using System;
using System.Collections.Generic;
using System.Text;

namespace ePizza_JD.Models
{
    public class Restaurant
    {
        public Guid RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }


        public ICollection<Order> Orders { get; set; }


        //navigation properties
        //public ICollection<RestaurantOrder> RestaurantOrder { get; set; }

    }
}
