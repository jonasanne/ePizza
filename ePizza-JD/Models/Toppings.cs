using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Toppings
    {
        public Guid ToppingId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
