using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Pizza
    {
        public Guid PizzaId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
    }
}
