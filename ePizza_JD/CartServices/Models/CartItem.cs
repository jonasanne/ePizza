using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CartServices.Models
{
    public enum Sizes
    {
        [Display(Name = "Small")]
        Small = 0,
        [Display(Name = "Medium")]
        Medium = 1,
        [Display(Name = "Large")]
        Large = 2,
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
    public class CartItem
    {
        [Key]
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public string PizzaName { get; set; } //wordt Recipe (Name of Id) of iets anders
        public double PizzaPrice { get; set; } //wordt RecipePrice of …
        public PizzaTypes PizzaType { get; set; }
        [Required]
        [EnumDataType(typeof(Sizes), ErrorMessage = "{0} is geen geldige keuze.")]
        [Range(0, 1, ErrorMessage = "Wrong Choice.")]
        public Sizes Size { get; set; }
        public int Quantity { get; set; }


        //een virtuele collectie voor relatie aanmaak public Guid CartId { get; set; }
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
