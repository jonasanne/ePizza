using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Order
    {
        public enum Sizes
        {
            [Display(Name = "Medium")]
            Medium = 0,
            [Display(Name = "Large")]
            Large = 1,
        };
        public enum Types
        {
            [Display(Name = "Glutenfree")]
            Glutenfree = 2,
            [Display(Name = "Vegetarian")]
            Vegetarian = 1,
            [Display(Name = "Normal")]
            Normal = 0,
        };


        public Guid OrderId { get; set; }
        public DateTime Date { get; set; } 
        public int Time { get; set; } // minutes
        [Required]
        public int Quantity { get; set; }

        [Required]
        [EnumDataType(typeof(Sizes), ErrorMessage = "{0} is geen geldige keuze.")]
        [Range(0, 1, ErrorMessage = "Wrong Choice.")]
        public Sizes Size { get; set; } 

        [Required]
        [EnumDataType(typeof(Sizes), ErrorMessage = "{0} is geen geldige keuze.")]
        [Range(0, 2, ErrorMessage = "Wrong Choice.")]
        public Types Type { get; set; }
        public Guid PizzaId { get; set; }




        //navigation Properties
        public Pizza Pizza { get; set; }

        public ICollection<OrderReviews> OrderReviews { get; set; }
        public ICollection<CustomerOrders> CustomerOrders { get; set; }



    }
}
