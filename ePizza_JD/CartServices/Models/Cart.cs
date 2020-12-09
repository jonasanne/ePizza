using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CartServices.Models
{
    public enum OrderTypes
    {
        [Display(Name = "Takeaway")]
        takeaway = 0,
        [Display(Name = "Delivery")]
        delivery = 1,
    };
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartId { get; set; } = Guid.NewGuid();
        //Cart eenduidig gelinkt met de user (besteller)


        [Required]
        [EnumDataType(typeof(OrderTypes), ErrorMessage = "{0} is geen geldige keuze.")]
        [Range(0, 1, ErrorMessage = "Wrong Choice.")]
        public OrderTypes OrderType { get; set; }

        public int TimeToPrepare { get; set; } // minutes
        public DateTime DateOfEntry { get; set; } = DateTime.Now;

        [Required]
        public Guid CustomerId { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
