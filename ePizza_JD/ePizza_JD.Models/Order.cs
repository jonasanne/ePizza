using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime Date { get; set; } 
        public DateTime Time { get; set; }
        [Required]
        public int Quantity { get; set; } 
        public Guid PizzaId { get; set; }


        //navigation Properties
        public Pizza Pizza { get; set; }

        public ICollection<OrderReviews> OrderReviews { get; set; }
        public ICollection<CustomerOrders> CustomerOrders { get; set; }



    }
}
