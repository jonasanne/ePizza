using OrderServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Order
    {

        public enum OrderTypes
        {
            [Display(Name = "Takeaway")]
            takeaway = 0,
            [Display(Name = "Delivery")]
            delivery = 1,
        };
        public Guid OrderId { get; set; }
        public DateTime Date { get; set; } 
        public int Time { get; set; } // minutes
        [Required]
        [EnumDataType(typeof(Sizes), ErrorMessage = "{0} is geen geldige keuze.")]
        [Range(0, 1, ErrorMessage = "Wrong Choice.")]
        public OrderTypes OrderType { get; set; }
        public IEnumerable<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}

