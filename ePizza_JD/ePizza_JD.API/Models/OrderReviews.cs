using System;
using System.Collections.Generic;
using System.Text;

namespace ePizza_JD.Models
{
    public class OrderReviews
    {
        public Guid OrderId { get; set; }
        public Guid ReviewId { get; set; }
        public string Subject { get; set; }


        //navigation properties
        public Order Order { get; set; }
        public Review Review { get; set; }

    }
}
