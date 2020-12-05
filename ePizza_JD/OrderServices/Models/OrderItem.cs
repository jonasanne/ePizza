using ePizza_JD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Models
{
    public enum Sizes
    {
        [Display(Name = "Medium")]
        Medium = 0,
        [Display(Name = "Large")]
        Large = 1,
    };
    public enum PizzaTypes
    {
        [Display(Name = "Glutenfree")]
        Glutenfree = 2,
        [Display(Name = "Vegetarian")]
        Vegetarian = 1,
        [Display(Name = "Normal")]
        Normal = 0,
    };
    public class OrderItem
    {

        public Guid OrderItemId { get; set; }

        public int Quantity { get; set; }

        public int PizzaId { get; private set; }


        [Required]
        [EnumDataType(typeof(Sizes), ErrorMessage = "{0} is geen geldige keuze.")]
        [Range(0, 1, ErrorMessage = "Wrong Choice.")]
        public Sizes Size { get; set; }

        [Required]
        [EnumDataType(typeof(Sizes), ErrorMessage = "{0} is geen geldige keuze.")]
        [Range(0, 2, ErrorMessage = "Wrong Choice.")]
        public PizzaTypes PizzaType { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

    }
}
