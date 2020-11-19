using System;
using System.Collections.Generic;
using System.Text;

namespace ePizza_JD.Models
{
    public class RestaurantOrder
    {
        public Guid OrderId { get; set; }
        public Guid RestaurantId { get; set; }



        //navigation properties
        public Restaurant Restaurant { get; set; }
        public Order Order { get; set; }

    }
}
