using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Pizza
    {

        [Key]
        public Guid PizzaId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
        public string ImgUrl { get; set; }



        //navigation properties
        //public ICollection<OrderReviews> OrderReviews { get; set; }
        public ICollection<PizzaToppings> PizzaToppings { get; set; }


    }
}
