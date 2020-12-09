using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartServices.Models
{
    public class CartItemDTO
    {
        public string PizzaName { get; set; } 
        public double PizzaPrice { get; set; }
        public PizzaTypes PizzaType { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
    }
}
