using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public Guid PizzaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
    }
}
