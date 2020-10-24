using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }



        //navigation properties
        public ICollection<CustomerOrders> CustomerOrders { get; set; }


    }
}
