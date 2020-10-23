using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
        public int TimeToPrepare { get; set; }
        public Guid PizzaId { get; set; }
    }
}
