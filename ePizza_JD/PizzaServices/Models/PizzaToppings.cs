using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePizza_JD.Models
{
    public class PizzaToppings
    {
        public Guid PizzaId { get; set; }
        public Guid ToppingId { get; set; }

        //noodzakelijk???
        //[Required]
        //public int TimeToPrepare { get; set; } //minuten

        public Pizza Pizza { get; set; }


        public Topping Topping { get; set; }
    }
}
