using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Pizza
    {

        public enum Sizes
        {
            [Display(Name = "Small")]
            Small = 0,
            [Display(Name = "Medium")]
            Medium = 1,
            [Display(Name = "Large")]
            Large = 2,
            [Display(Name = "Extra-Large")]
            xLarge = 3,


        };

        

        [Key]
        public Guid PizzaId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [EnumDataType(typeof(Sizes), ErrorMessage ="{0} is geen geldige keuze.")]
        [Range(0,3, ErrorMessage ="Wrong Choice.")]
        public Sizes Size { get; set; }

        // xlarge,large,medium,small

        //navigation properties
        public ICollection<OrderReviews> OrderReviews { get; set; }
        public ICollection<PizzaToppings> PizzaToppings { get; set; }


    }
}
