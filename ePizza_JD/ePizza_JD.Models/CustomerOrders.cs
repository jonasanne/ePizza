using System;
using System.Collections.Generic;
using System.Text;

namespace ePizza_JD.Models
{
    public class CustomerOrders
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }



        //navigation properties
        public Customer Customer { get; set; }
        public Order Order { get; set; }

    }
}
