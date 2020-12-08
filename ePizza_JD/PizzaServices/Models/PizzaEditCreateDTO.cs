using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePizza_JD.Models
{
    public class PizzaEditCreateDTO
    {

        [Key]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string ImgUrl { get; set; }
        public ICollection<Topping> Toppings { get; set; }





    }
}
